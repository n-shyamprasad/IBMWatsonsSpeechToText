
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Helper;
using IBM.Cloud.SDK.Core.Authentication.Iam;
using IBM.Cloud.SDK.Core.Http.Exceptions;
using IBM.Watson.SpeechToText.v1;
using IBM.Watson.SpeechToText.v1.Model;
using NLog;

namespace Transcriber
{
    public partial class frmAudio : Form
	{
		private static Logger NLogger = LogManager.GetLogger("Transcriber");
		string apiKey = string.Empty;
		string apiServiceUrl = string.Empty;
		string AudioFilesPath = string.Empty;
		string TextFilesPath = string.Empty;
		string AudioFormats = string.Empty;
		SpeechRecognitionResult speechRecognitionResult = new SpeechRecognitionResult();
		//StringBuilder sbTrace;

		private string[] AudioFiles
        {
			set;
			get;          
        }

		private List<AudioFile> ListAudioFiles
        {
			set; 
			get;
        }
		public frmAudio()
		{
			InitializeComponent();		
		}
        private void frmAudio_Load(object sender, System.EventArgs e)
        {
			apiKey = Utils.GetConfig("apiKey");
			apiServiceUrl = Utils.GetConfig("apiServiceUrl");
			AudioFilesPath = Utils.GetConfig("AudioFilesPath");
			TextFilesPath = Utils.GetConfig("TextFilesPath");
			AudioFormats = Utils.GetConfig("SupportedAudioFormat");
			LoadInput();
		}	
		private void LoadInput()
        {
			if (Directory.Exists(@AudioFilesPath))
			{
				AudioFiles = Utils.getFiles(@AudioFilesPath, AudioFormats, SearchOption.TopDirectoryOnly);
				lblAudioFilePath.Text = @AudioFilesPath;
				lblCount.Text = AudioFiles.Count().ToString();

				if (AudioFiles.Count() > 0)
				{
					ListAudioFiles = GetAudioFileDetails(AudioFiles);
					btnConvert.Enabled = true;
				}
				else
				{
					MessageBox.Show("No Files to process!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					btnConvert.Enabled = false;
				}
			}
			else
			{
				MessageBox.Show("Audio Files folder does not exists!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				btnConvert.Enabled = false;
			}
		}

		private List<AudioFile> GetAudioFileDetails(string[] audioFiles)
        {
			//DirectoryInfo di = new DirectoryInfo("c:\\");
			//FileInfo[] fiArr = di.GetFiles();
			List<AudioFile> lstAudioFiles = new List<AudioFile>();
			foreach (var item in audioFiles)
            {
				lstAudioFiles.Add(new AudioFile
				{
					Filename = Path.GetFileName(item.ToString()),
					FilenameWithoutExtension = Path.GetFileNameWithoutExtension(item.ToString()),
					FullFilename = item,
					FileFormat = Path.GetExtension(item.ToString()).Replace(".",""),					
					Filesize = 0
				});
			}
			return lstAudioFiles;
		}

		private SpeechRecognitionResult ProcessAudio(SpeechToTextService speechToText, string FilePath, string Format)
        {
			try
			{
				using (MemoryStream memoryStream = new MemoryStream(File.ReadAllBytes(@FilePath)))
				{
					var result = speechToText.Recognize(audio: memoryStream,
						contentType: "audio/" + Format,
						wordAlternativesThreshold: 0.9f);
					return ((SpeechRecognitionResults)result.Result).Results[0];
					//speechRecognitionResult.Results[0].Alternatives[0].Transcript.ToString();		
				}
			}
			catch(ServiceResponseException Err)
            {
				throw Err;
            }
			catch (Exception Err)
			{
				throw Err;
			}
		}

		private void WriteTranscript(string sTranscript, string OutputFileName)
        {
			OutputFileName = TextFilesPath + "\\" + OutputFileName + ".txt";
			File.WriteAllText(OutputFileName, sTranscript);
        }
		private IamAuthenticator GetAuthenticator(string apiKey)
        {
			IamAuthenticator authenticator = new IamAuthenticator(apikey: apiKey);
			return authenticator;
		}
		private SpeechToTextService GetSpeechToTextService(IamAuthenticator iamAuthenticator, string ServiceUrl)
        {
			SpeechToTextService speechToText = new SpeechToTextService(iamAuthenticator);
			speechToText.SetServiceUrl(ServiceUrl);
			return speechToText;
		}
		
		private bool Validation()
        {
			bool result = true;
			if(string.IsNullOrEmpty(apiKey))
            {
				MessageBox.Show("Must provide API key in config file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				result = false;
			}
			else if (string.IsNullOrEmpty(apiServiceUrl))
			{
				MessageBox.Show("Must provide API Service URL in config file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				result = false;
			}
			else if (string.IsNullOrEmpty(AudioFormats))
			{
				MessageBox.Show("Must provide Audio Formats in config file!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				result = false;
			}

			return result;

		}
        private void btnConvert_Click(object sender, System.EventArgs e)
        {
			if (Validation())
			{
				if (bgWorker.IsBusy != true)
				{
					Progress.Maximum = 100;
					Progress.Step = 10;
					Progress.Value = 10;
					btnConvert.Enabled = false;
					// Start the asynchronous operation.
					bgWorker.RunWorkerAsync();
				}
			}			
		}

        private void bgWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
			//var backgroundWorker = sender as BackgroundWorker;
			//sbTrace = new StringBuilder();
			try
			{
				if (ListAudioFiles.Count > 0)
				{
					int Counter = ListAudioFiles.Count;
					SpeechToTextService speechToText = GetSpeechToTextService(GetAuthenticator(apiKey), apiServiceUrl);
					if (speechToText != null)
					{
						foreach (var item in ListAudioFiles)
						{
							speechRecognitionResult = ProcessAudio(speechToText, item.FullFilename, item.FileFormat);
							
							if (speechRecognitionResult != null)
							{
								WriteTranscript(speechRecognitionResult.Alternatives[0].Transcript, item.FilenameWithoutExtension);
								bgWorker.ReportProgress(100/ Counter);
								Counter--;
								//sbTrace.AppendLine(string.Format("{0} >> processed >> {1}", item.Filename, item.FilenameWithoutExtension+".txt"));								
							}
						}
					}
				}
			}
			catch (Exception Err)
			{
				NLogger.Error(Err.Message);
				NLogger.Error(Err.InnerException);
			}
			finally
			{

			}
		}

        private void bgWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
			Progress.Value = e.ProgressPercentage;
		}

        private void bgWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
			Progress.Value = 100;
			lblOutputPath.Text = "Text File Path: " + TextFilesPath;
			btnConvert.Enabled = true;
        }
    }

    public class AudioFile
    {
		public string Filename { set; get; }
		public string FilenameWithoutExtension { set; get; }
		public string FullFilename { set; get; }
		public string FileFormat { set; get; }
		public int Filesize { set; get; }
    }
}