using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.IO.Packaging;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace ProjectMigrationUtility.FileManager
{
    public class FileSelectionManager
    {
		private int affectedFiles;

		private int involvedFiles;

		private List<FileInfo> selectedFiles = new List<FileInfo>();

		private Dictionary<string, object> appConfig = new Dictionary<string, object>();

		public int AffectedFiles
		{
			get
			{
				return this.affectedFiles;
			}
			private set
			{
				this.affectedFiles = value;
			}
		}

		private Dictionary<string, object> AppConfig
		{
			get
			{
				return this.appConfig;
			}
			set
			{
				this.appConfig = value;
			}
		}

		public int InvolvedFiles
		{
			get
			{
				return this.involvedFiles;
			}
			private set
			{
				this.involvedFiles = value;
			}
		}

		public List<FileInfo> SelectedFiles
		{
			get
			{
				return this.selectedFiles;
			}
			private set
			{
				this.selectedFiles = value;
			}
		}

		public FileSelectionManager()
		{
			this.loadAppConfiguration();
		}

		public void AddPrefixToFileName(string fullPathSource, bool recursive, string whereClause, string prefix)
		{
			Log.WriteLog(" -- Init -- ", "Log", this.GetType().Name, this.AppConfig);
			foreach (FileInfo file in this.SelectFiles(fullPathSource, recursive, whereClause))
			{
				try
				{
					if (!File.Exists(string.Concat(file.DirectoryName, "\\", file.Name)))
					{
						FileSelectionManager affectedFiles = this;
						affectedFiles.AffectedFiles = affectedFiles.AffectedFiles - 1;
					}
					else
					{
						File.Move(string.Concat(file.DirectoryName, "\\", file.Name), string.Concat(file.DirectoryName, "\\", prefix, file.Name));
					}
				}
				catch (Exception exception)
				{
					Exception e = exception;
					Log.WriteLog(e.Message, "Error", this.GetType().Name, this.AppConfig);
					throw e;
				}
			}
		}

		public void AddSuffixToFileName(string fullPathSource, bool recursive, string whereClause, string suffix)
		{
			Log.WriteLog(" -- Init -- ", "Log", this.GetType().Name, this.AppConfig);
			foreach (FileInfo file in this.SelectFiles(fullPathSource, recursive, whereClause))
			{
				try
				{
					if (!File.Exists(string.Concat(file.DirectoryName, "\\", file.Name)))
					{
						FileSelectionManager affectedFiles = this;
						affectedFiles.AffectedFiles = affectedFiles.AffectedFiles - 1;
					}
					else
					{
						string str = string.Concat(file.DirectoryName, "\\", file.Name);
						string[] directoryName = new string[] { file.DirectoryName, "\\", null, null, null };
						directoryName[2] = (file.Extension != string.Empty ? file.Name.Replace(file.Extension, "") : file.Name);
						directoryName[3] = suffix;
						directoryName[4] = file.Extension;
						File.Move(str, string.Concat(directoryName));
					}
				}
				catch (Exception exception)
				{
					Exception e = exception;
					Log.WriteLog(e.Message, "Error", this.GetType().Name, this.AppConfig);
					throw e;
				}
			}
		}

		public void ChangeExtension(string fullPathSource, bool recursive, string whereClause, string newExtension)
		{
			Log.WriteLog(" -- Init -- ", "Log", this.GetType().Name, this.AppConfig);
			foreach (FileInfo file in this.SelectFiles(fullPathSource, recursive, whereClause))
			{
				try
				{
					if (!File.Exists(string.Concat(file.DirectoryName, "\\", file.Name)))
					{
						FileSelectionManager affectedFiles = this;
						affectedFiles.AffectedFiles = affectedFiles.AffectedFiles - 1;
					}
					else if (file.Extension != string.Empty)
					{
						File.Move(string.Concat(file.DirectoryName, "\\", file.Name), string.Concat(file.DirectoryName, "\\", file.Name.Replace(file.Extension, ""), newExtension));
					}
				}
				catch (Exception exception)
				{
					Exception e = exception;
					Log.WriteLog(e.Message, "Error", this.GetType().Name, this.AppConfig);
					throw e;
				}
			}
		}

		public void CopyFiles(string fullPathSource, bool recursive, string whereClause, string fullPathDestination, bool overWrite)
		{
			Log.WriteLog(" -- Init -- ", "Log", this.GetType().Name, this.AppConfig);
			foreach (FileInfo file in this.SelectFiles(fullPathSource, recursive, whereClause, fullPathDestination))
			{
				try
				{
					if (!File.Exists(string.Concat(fullPathDestination, "\\", file.Name)) || overWrite)
					{
						File.Copy(string.Concat(file.DirectoryName, "\\", file.Name), string.Concat(fullPathDestination, "\\", file.Name), true);
					}
					else
					{
						FileSelectionManager affectedFiles = this;
						affectedFiles.AffectedFiles = affectedFiles.AffectedFiles - 1;
					}
				}
				catch (Exception exception)
				{
					Exception e = exception;
					Log.WriteLog(e.Message, "Error", this.GetType().Name, this.AppConfig);
					throw e;
				}
			}
		}

		public void CopyFilesAndStructure(string fullPathSource, bool recursive, string whereClause, string fullPathDestination, bool overWrite)
		{
			Log.WriteLog(" -- Init -- ", "Log", this.GetType().Name, this.AppConfig);
			foreach (FileInfo file in this.SelectFiles(fullPathSource, recursive, whereClause, fullPathDestination))
			{
				try
				{
					string pathDestinationPlusDirectoryName = string.Concat(fullPathDestination, this.RemoveDrivefromDirectory(file.DirectoryName));
					if (!Directory.Exists(pathDestinationPlusDirectoryName))
					{
						Directory.CreateDirectory(pathDestinationPlusDirectoryName);
					}
					if (!File.Exists(string.Concat(pathDestinationPlusDirectoryName, "\\", file.Name)) || overWrite)
					{
						File.Copy(string.Concat(file.DirectoryName, "\\", file.Name), string.Concat(pathDestinationPlusDirectoryName, "\\", file.Name), true);
					}
					else
					{
						FileSelectionManager affectedFiles = this;
						affectedFiles.AffectedFiles = affectedFiles.AffectedFiles - 1;
					}
				}
				catch (Exception exception)
				{
					Exception e = exception;
					Log.WriteLog(e.Message, "Error", this.GetType().Name, this.AppConfig);
					throw e;
				}
			}
		}

		public void CopyStructureAndMoveFiles(string fullPathSource, bool recursive, string whereClause, string fullPathDestination, bool forceToMove)
		{
			Log.WriteLog(" -- Init -- ", "Log", this.GetType().Name, this.AppConfig);
			foreach (FileInfo file in this.SelectFiles(fullPathSource, recursive, whereClause, fullPathDestination))
			{
				try
				{
					string pathDestinationPlusDirectoryName = string.Concat(fullPathDestination, this.RemoveDrivefromDirectory(file.DirectoryName));
					if (!Directory.Exists(pathDestinationPlusDirectoryName))
					{
						Directory.CreateDirectory(pathDestinationPlusDirectoryName);
					}
					if (!File.Exists(string.Concat(pathDestinationPlusDirectoryName, "\\", file.Name)) || forceToMove)
					{
						if (File.Exists(string.Concat(pathDestinationPlusDirectoryName, "\\", file.Name)))
						{
							File.Delete(string.Concat(pathDestinationPlusDirectoryName, "\\", file.Name));
						}
						File.Move(string.Concat(file.DirectoryName, "\\", file.Name), string.Concat(pathDestinationPlusDirectoryName, "\\", file.Name));
					}
					else
					{
						FileSelectionManager affectedFiles = this;
						affectedFiles.AffectedFiles = affectedFiles.AffectedFiles - 1;
					}
				}
				catch (Exception exception)
				{
					Exception e = exception;
					Log.WriteLog(e.Message, "Error", this.GetType().Name, this.AppConfig);
					throw e;
				}
			}
		}

		private void createLogFile()
		{
			if (Convert.ToBoolean(this.AppConfig["ACTIVE"]))
			{
				string pathLog = Convert.ToString(this.AppConfig["FULLPATH"]);
				string pathAndFile = string.Concat(Convert.ToString(this.AppConfig["FULLPATH"]), "\\", Convert.ToString(this.AppConfig["FILENAME"]));
				if (!File.Exists(pathAndFile))
				{
					if (!Directory.Exists(pathLog))
					{
						Directory.CreateDirectory(pathLog);
					}
					File.Create(pathAndFile).Close();
				}
			}
		}

		public void DeleteFiles(string fullPathSource, bool recursive, string whereClause)
		{
			Log.WriteLog(" -- Init -- ", "Log", this.GetType().Name, this.AppConfig);
			foreach (FileInfo file in this.SelectFiles(fullPathSource, recursive, whereClause))
			{
				try
				{
					if (!File.Exists(string.Concat(file.DirectoryName, "\\", file.Name)))
					{
						FileSelectionManager affectedFiles = this;
						affectedFiles.AffectedFiles = affectedFiles.AffectedFiles - 1;
					}
					else
					{
						File.Delete(string.Concat(file.DirectoryName, "\\", file.Name));
					}
				}
				catch (Exception exception)
				{
					Exception e = exception;
					Log.WriteLog(e.Message, "Error", this.GetType().Name, this.AppConfig);
					throw e;
				}
			}
		}

		public List<FileInfo> Dir(string fullPath, bool recursive, string whereClause)
		{
			Log.WriteLog(" -- Init -- ", "Log", this.GetType().Name, this.AppConfig);
			List<FileInfo> files = this.SelectFiles(fullPath, recursive, whereClause);
			this.AffectedFiles = 0;
			return files;
		}

		private void fillResultProperties(List<FileInfo> selectedFiles)
		{
			this.AffectedFiles = selectedFiles.Count;
			this.InvolvedFiles = selectedFiles.Count;
			this.SelectedFiles = selectedFiles;
			if (this.AppConfig.Count > 0 && Convert.ToBoolean(this.AppConfig["LISTAFFECTEDFILES"]))
			{
				string logMessage = "\n\r";
				foreach (FileInfo file in this.SelectedFiles)
				{
					object obj = logMessage;
					object[] directoryName = new object[] { obj, file.DirectoryName, " ", file.Name, " ", file.Extension, " ", file.CreationTime, " ", file.Length, "\n\r" };
					logMessage = string.Concat(directoryName);
				}
				Log.WriteLog(logMessage, "Log", this.GetType().Name, this.AppConfig);
			}
		}

		private List<FileInfo> GetFiles(string mainDirectory, bool includeSubDirectories)
		{
			List<FileInfo> list;
			DirectoryInfo directory = new DirectoryInfo(mainDirectory);
			List<FileInfo> files = new List<FileInfo>();
			try
			{
				list = this.GetFilesFromDirectory(directory, includeSubDirectories).ToList<FileInfo>();
			}
			catch (Exception exception)
			{
				Exception e = exception;
				Log.WriteLog(e.Message, "Error", this.GetType().Name, this.AppConfig);
				throw e;
			}
			return list;
		}

		private List<FileInfo> GetFilesFromDirectory(DirectoryInfo directory, bool includeSubDirectories)
		{
			List<FileInfo> fileInfos;
			FileInfo[] filesArray = directory.GetFiles("*.*");
			List<FileInfo> files = new List<FileInfo>();
			FileInfo[] fileInfoArray = filesArray;
			for (int i = 0; i < (int)fileInfoArray.Length; i++)
			{
				FileInfo f = fileInfoArray[i];
				try
				{
					string fullName = f.FullName;
					files.Add(f);
				}
				catch (PathTooLongException pathTooLongException)
				{
					string[] str = new string[] { "Directory: ", directory.ToString(), " File: ", f.ToString(), " Excluded from selection as path too long " };
					Log.WriteLog(string.Concat(str), "Error", this.GetType().Name, this.AppConfig);
				}
			}
			try
			{
				if (includeSubDirectories)
				{
					DirectoryInfo[] directories = directory.GetDirectories();
					for (int j = 0; j < (int)directories.Length; j++)
					{
						DirectoryInfo aDirectory = directories[j];
						try
						{
							files.AddRange(this.GetFilesFromDirectory(aDirectory, true));
						}
						catch
						{
						}
					}
				}
				fileInfos = files;
			}
			catch (UnauthorizedAccessException unauthorizedAccessException)
			{
				UnauthorizedAccessException e = unauthorizedAccessException;
				Log.WriteLog(e.Message, "Error", this.GetType().Name, this.AppConfig);
				throw e;
			}
			catch (DirectoryNotFoundException directoryNotFoundException)
			{
				DirectoryNotFoundException e = directoryNotFoundException;
				Log.WriteLog(e.Message, "Error", this.GetType().Name, this.AppConfig);
				throw e;
			}
			return fileInfos;
		}

		private void loadAppConfiguration()
		{
			FileSelectionManagerLogSection logSection = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None).GetSection("FileSelectionManagerLog") as FileSelectionManagerLogSection;
			if (logSection != null)
			{
				if (logSection.Logging.FullPath != null && logSection.Logging.FullPath != string.Empty)
				{
					this.AppConfig.Add("FULLPATH", logSection.Logging.FullPath);
				}
				if (logSection.Logging.FileName != null && logSection.Logging.FileName != string.Empty)
				{
					this.AppConfig.Add("FILENAME", logSection.Logging.FileName);
				}
				bool listAffectedFiles = logSection.Logging.ListAffectedFiles;
				this.AppConfig.Add("LISTAFFECTEDFILES", logSection.Logging.ListAffectedFiles);
				bool active = logSection.Logging.Active;
				this.AppConfig.Add("ACTIVE", logSection.Logging.Active);
				try
				{
					this.createLogFile();
				}
				catch (IOException oException)
				{
				}
			}
		}

		public void MoveFiles(string fullPathSource, bool recursive, string whereClause, string fullPathDestination, bool forceToMove)
		{
			Log.WriteLog(" -- Init -- ", "Log", this.GetType().Name, this.AppConfig);
			foreach (FileInfo file in this.SelectFiles(fullPathSource, recursive, whereClause, fullPathDestination))
			{
				try
				{
					if (!File.Exists(string.Concat(fullPathDestination, "\\", file.Name)) || forceToMove)
					{
						if (File.Exists(string.Concat(fullPathDestination, "\\", file.Name)))
						{
							File.Delete(string.Concat(fullPathDestination, "\\", file.Name));
						}
						File.Move(string.Concat(file.DirectoryName, "\\", file.Name), string.Concat(fullPathDestination, "\\", file.Name));
					}
					else
					{
						FileSelectionManager affectedFiles = this;
						affectedFiles.AffectedFiles = affectedFiles.AffectedFiles - 1;
					}
				}
				catch (Exception exception)
				{
					Exception e = exception;
					Log.WriteLog(e.Message, "Error", this.GetType().Name, this.AppConfig);
					throw e;
				}
			}
		}

		private string RemoveDrivefromDirectory(string fullPath)
		{
			return fullPath.Replace(Directory.GetDirectoryRoot(fullPath), "\\");
		}

		public void RenameFiles(string fullPathSource, bool recursive, string whereClause, string newFileName)
		{
			Log.WriteLog(" -- Init -- ", "Log", this.GetType().Name, this.AppConfig);
			foreach (FileInfo file in this.SelectFiles(fullPathSource, recursive, whereClause))
			{
				try
				{
					if (!File.Exists(string.Concat(file.DirectoryName, "\\", file.Name)))
					{
						FileSelectionManager affectedFiles = this;
						affectedFiles.AffectedFiles = affectedFiles.AffectedFiles - 1;
					}
					else
					{
						File.Move(string.Concat(file.DirectoryName, "\\", file.Name), string.Concat(file.DirectoryName, "\\", newFileName));
					}
				}
				catch (Exception exception)
				{
					Exception e = exception;
					Log.WriteLog(e.Message, "Error", this.GetType().Name, this.AppConfig);
					throw e;
				}
			}
		}

		public void ReplaceRegexInFileName(string fullPathSource, bool recursive, string whereClause, string pattern, string newValue)
		{
			Log.WriteLog(" -- Init -- ", "Log", this.GetType().Name, this.AppConfig);
			foreach (FileInfo file in this.SelectFiles(fullPathSource, recursive, whereClause))
			{
				try
				{
					if (!File.Exists(string.Concat(file.DirectoryName, "\\", file.Name)) || !Regex.IsMatch(file.Name, pattern))
					{
						FileSelectionManager affectedFiles = this;
						affectedFiles.AffectedFiles = affectedFiles.AffectedFiles - 1;
					}
					else if (pattern != string.Empty)
					{
						string fileNameReplaced = Regex.Replace(file.Name, pattern, newValue);
						File.Move(string.Concat(file.DirectoryName, "\\", file.Name), string.Concat(file.DirectoryName, "\\", fileNameReplaced));
					}
				}
				catch (Exception exception)
				{
					Exception e = exception;
					Log.WriteLog(e.Message, "Error", this.GetType().Name, this.AppConfig);
					throw e;
				}
			}
		}

		public void ReplaceValueInFileName(string fullPathSource, bool recursive, string whereClause, string oldValue, string newValue)
		{
			Log.WriteLog(" -- Init -- ", "Log", this.GetType().Name, this.AppConfig);
			foreach (FileInfo file in this.SelectFiles(fullPathSource, recursive, whereClause))
			{
				try
				{
					if (!File.Exists(string.Concat(file.DirectoryName, "\\", file.Name)) || file.Name.IndexOf(oldValue) < 0)
					{
						FileSelectionManager affectedFiles = this;
						affectedFiles.AffectedFiles = affectedFiles.AffectedFiles - 1;
					}
					else if (oldValue != string.Empty)
					{
						File.Move(string.Concat(file.DirectoryName, "\\", file.Name), string.Concat(file.DirectoryName, "\\", file.Name.Replace(oldValue, newValue)));
					}
				}
				catch (Exception exception)
				{
					Exception e = exception;
					Log.WriteLog(e.Message, "Error", this.GetType().Name, this.AppConfig);
					throw e;
				}
			}
		}

		private List<FileInfo> SelectFiles(string fullPathSource, bool recursive, string whereClause)
		{
			object[] objArray = new object[] { "SOURCE:", fullPathSource, " RECURSIVE: ", recursive };
			Log.WriteLog(string.Concat(objArray), "Log", this.GetType().Name, this.AppConfig);
			try
			{
				this.ValidatePath(fullPathSource);
			}
			catch (DirectoryNotFoundException directoryNotFoundException)
			{
				DirectoryNotFoundException e = directoryNotFoundException;
				Log.WriteLog(e.Message, "Error", this.GetType().Name, this.AppConfig);
				throw e;
			}
			WhereManager wManager = new WhereManager(this.AppConfig);
			List<FileInfo> selectedFiles = wManager.SelectFiles(this.GetFiles(fullPathSource, recursive), whereClause);
			this.fillResultProperties(selectedFiles);
			return selectedFiles;
		}

		private List<FileInfo> SelectFiles(string fullPathSource, bool recursive, string whereClause, string fullPathDestination)
		{
			object[] objArray = new object[] { "SOURCE:", fullPathSource, " RECURSIVE: ", recursive, " DEST: ", fullPathDestination };
			Log.WriteLog(string.Concat(objArray), "Log", this.GetType().Name, this.AppConfig);
			try
			{
				this.ValidateSourceAndDestination(fullPathSource, fullPathDestination);
			}
			catch (DirectoryNotFoundException directoryNotFoundException)
			{
				DirectoryNotFoundException e = directoryNotFoundException;
				Log.WriteLog(e.Message, "Error", this.GetType().Name, this.AppConfig);
				throw e;
			}
			WhereManager wManager = new WhereManager(this.AppConfig);
			List<FileInfo> selectedFiles = wManager.SelectFiles(this.GetFiles(fullPathSource, recursive), whereClause);
			this.fillResultProperties(selectedFiles);
			return selectedFiles;
		}

		public void Unzip(string fullPathZipFile, string fullPathToUnzip, bool unZipWithDirectoryStructure)
		{
			int Size;
			Log.WriteLog(" -- Init -- ", "Log", this.GetType().Name, this.AppConfig);
			System.IO.FileStream zipFileStream = null;
			string location = string.Empty;
			try
			{
				if (Path.GetExtension(fullPathZipFile).ToLower() != ".zip")
				{
					throw new IOException("File Extension in not valid");
				}
				if (!File.Exists(fullPathZipFile))
				{
					throw new FileNotFoundException("Zip file not found");
				}
				zipFileStream = new System.IO.FileStream(fullPathZipFile, FileMode.Open);
				try
				{
					this.ValidatePath(fullPathToUnzip);
				}
				catch (DirectoryNotFoundException directoryNotFoundException)
				{
					Log.WriteLog(string.Concat("Create Directory ", fullPathToUnzip), "Log", this.GetType().Name, this.AppConfig);
					Directory.CreateDirectory(fullPathToUnzip);
				}
				using (System.IO.Packaging.Package Package = System.IO.Packaging.Package.Open(zipFileStream, FileMode.Open, FileAccess.Read))
				{
					foreach (PackageRelationship Relationship in Package.GetRelationshipsByType("http://schemas.microsoft.com/opc/2006/sample/document"))
					{
						Uri UriTarget = PackUriHelper.ResolvePartUri(new Uri("/", UriKind.Relative), Relationship.TargetUri);
						PackagePart document = Package.GetPart(UriTarget);
						location = (!unZipWithDirectoryStructure ? string.Concat(fullPathToUnzip, "\\", Path.GetFileName(HttpUtility.UrlDecode(document.Uri.ToString()).Replace('\\', '/'))) : string.Concat(fullPathToUnzip, HttpUtility.UrlDecode(document.Uri.ToString()).Replace('\\', '/')));
						string folder = Path.GetDirectoryName(location);
						try
						{
							this.ValidatePath(folder);
						}
						catch (DirectoryNotFoundException directoryNotFoundException1)
						{
							Log.WriteLog(string.Concat("Create Directory ", folder), "Log", this.GetType().Name, this.AppConfig);
							Directory.CreateDirectory(folder);
						}
						byte[] Data = new byte[1024];
						using (System.IO.FileStream FileStream = new System.IO.FileStream(location, FileMode.Create))
						{
							Stream DocumentStream = document.GetStream();
							do
							{
								Size = DocumentStream.Read(Data, 0, 1024);
								FileStream.Write(Data, 0, Size);
							}
							while (Size == 1024);
							FileStream.Close();
						}
						FileSelectionManager affectedFiles = this;
						affectedFiles.AffectedFiles = affectedFiles.AffectedFiles + 1;
						FileSelectionManager involvedFiles = this;
						involvedFiles.InvolvedFiles = involvedFiles.InvolvedFiles + 1;
					}
					if (File.Exists(string.Concat(fullPathToUnzip, "\\[Content_Types].xml")))
					{
						File.Delete(string.Concat(fullPathToUnzip, "\\[Content_Types].xml"));
					}
				}
			}
			catch (Exception exception)
			{
				Exception e = exception;
				Log.WriteLog(e.Message, "Error", this.GetType().Name, this.AppConfig);
				throw e;
			}
		}

		private void ValidatePath(string path)
		{
			if (!Directory.Exists(path))
			{
				throw new DirectoryNotFoundException();
			}
		}

		private void ValidateSourceAndDestination(string fullPathSource, string fullPathDestination)
		{
			try
			{
				this.ValidatePath(fullPathSource);
			}
			catch (DirectoryNotFoundException directoryNotFoundException)
			{
				DirectoryNotFoundException e = directoryNotFoundException;
				Log.WriteLog(e.Message, "Error", this.GetType().Name, this.AppConfig);
				throw e;
			}
			try
			{
				this.ValidatePath(fullPathDestination);
			}
			catch (DirectoryNotFoundException directoryNotFoundException1)
			{
				Log.WriteLog(string.Concat("Create Directory ", fullPathDestination), "Log", this.GetType().Name, this.AppConfig);
				Directory.CreateDirectory(fullPathDestination);
			}
		}

		public void Zip(string fullPathSource, bool recursive, string whereClause, string fullPathDestination, string zipFileName, bool overWrite)
		{
			Log.WriteLog(" -- Init -- ", "Log", this.GetType().Name, this.AppConfig);
			List<FileInfo> selectedFiles = this.SelectFiles(fullPathSource, recursive, whereClause, fullPathDestination);
			if (File.Exists(string.Concat(fullPathDestination, "\\", zipFileName)) && overWrite)
			{
				File.Delete(string.Concat(fullPathDestination, "\\", zipFileName));
			}
			else if (File.Exists(string.Concat(fullPathDestination, "\\", zipFileName)))
			{
				throw new IOException("File already exists");
			}
			string location = string.Concat(fullPathDestination, "\\", zipFileName);
			if (Path.GetExtension(location).ToLower() != ".zip")
			{
				throw new IOException("File Extension in not valid");
			}
			FileStream ZipFileStream = new FileStream(location, FileMode.Create);
			using (System.IO.Packaging.Package Package = System.IO.Packaging.Package.Open(ZipFileStream, FileMode.OpenOrCreate))
			{
				foreach (FileInfo file in selectedFiles)
				{
					try
					{
						string[] strArrays = new string[] { string.Concat(this.RemoveDrivefromDirectory(file.DirectoryName), "\\", file.Name) };
						Uri UriPath = PackUriHelper.CreatePartUri(new Uri(Path.Combine(strArrays), UriKind.Relative));
						System.IO.Packaging.PackagePart PackagePart = Package.CreatePart(UriPath, "text/xml", CompressionOption.Maximum);
						string[] strArrays1 = new string[] { string.Concat(file.DirectoryName, "\\", file.Name) };
						byte[] Data = File.ReadAllBytes(Path.Combine(strArrays1));
						PackagePart.GetStream().Write(Data, 0, Data.Count<byte>());
						Package.CreateRelationship(PackagePart.Uri, TargetMode.Internal, "http://schemas.microsoft.com/opc/2006/sample/document");
					}
					catch (Exception exception)
					{
						Exception e = exception;
						Log.WriteLog(e.Message, "Error", this.GetType().Name, this.AppConfig);
						throw e;
					}
				}
			}
			ZipFileStream.Close();
		}
	}
}