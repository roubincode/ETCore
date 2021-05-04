using UnityEditor;
using ETModel;
using System.IO;
namespace ETEditor
{
    public class BuildAssetBundles
    {
        public static string WebResFolder = "../WebRes/{0}/StreamingAssets/";

        public static void BuildAllAssetBundles(PlatformType type)
        {
            string resFolder  = string.Format(WebResFolder, type);
			if (!Directory.Exists(resFolder))
			{
				Directory.CreateDirectory(resFolder);
			}
            BundlePacker.DeleteAsset(resFolder);
            BundlePacker.DeleteAsset(PathHelper.AppHotfixResPath);

    #if UNITY_ANDROID
            BuildPipeline.BuildAssetBundles(resFolder, BuildAssetBundleOptions.None, BuildTarget.Android);
    #elif UNITY_IOS
            BuildPipeline.BuildAssetBundles(resFolder, BuildAssetBundleOptions.None, BuildTarget.iOS);
    #elif UNITY_WEBGL
            BuildPipeline.BuildAssetBundles(resFolder, BuildAssetBundleOptions.None, BuildTarget.WebGL);
    #elif UNITY_STANDALONE_OSX
            BuildPipeline.BuildAssetBundles(resFolder, BuildAssetBundleOptions.None, BuildTarget.StandaloneOSX);
    #else
            BuildPipeline.BuildAssetBundles(resFolder, BuildAssetBundleOptions.None, BuildTarget.StandaloneWindows64);
    #endif
            BundlePacker.Modify();
            AssetDatabase.Refresh();
        }
    }

    public static class BundlePacker
    {
        //获得指定VersionConfig对象中指定地址资源文件的MD5
        public static string GetBundleMD5(string bundleName,string dir)
        {
            string path = Path.Combine(dir, bundleName);
            if (File.Exists(path))
            {
                //Log.Debug(bundleName+"本地文件的MD5:" + MD5Helper.FileMD5(path));
                return MD5Helper.FileMD5(path);
            }

            return "";
        }

        //获取单个文件大小
        public static long GetBundleSize(string bundleName,string dir)
        {
            string path = Path.Combine(dir, bundleName);
            if (File.Exists(path))
            {
                using (FileStream fs = new FileStream(path, FileMode.Open))
                {
                    byte[] data = new byte[9999999];
                    long size = fs.Read(data, 0, data.Length);
                    //Log.Debug(bundleName + "文件Size为:" + size);
                    return size;
                }
            }

            return 0;
        }

        //获得VersionConfig对象
        public static VersionConfig GetVersionConfig()
        {
            // 获取streaming目录的Version.txt
            VersionConfig streamingVersionConfig;
            string versionPath = PathHelper.AppHotfixResPath + "/Version.txt";
            using (UnityWebRequestAsync request = ComponentFactory.Create<UnityWebRequestAsync>())
            {
                request.DownloadAsync(versionPath);
                streamingVersionConfig = JsonHelper.FromJson<VersionConfig>(request.Request.downloadHandler.text);
                //Log.Debug("本地Version.txt" + JsonHelper.ToJson(streamingVersionConfig));
            }
            return streamingVersionConfig;
        }

        //删除全部热更新文件
        public static void DeleteAsset(string dir)
        {
            //获取本地热更新文件目录地址
            DirectoryInfo directoryInfo = new DirectoryInfo(dir);
            if (directoryInfo.Exists)
            {
                //删除所有本地文件
                FileInfo[] fileInfos = directoryInfo.GetFiles();
                foreach (FileInfo fileInfo in fileInfos)
                {
                    fileInfo.Delete();
                }
            }
            else
            {
                Log.Error("热更新目录不存在");
            }
        }

        //创建Version.txt
        public static void Modify()
        {
            PlatformType type;
            VersionConfig newVersionconfig = new VersionConfig();
            newVersionconfig.Version = (int)TimeHelper.ClientNowSeconds();

    #if UNITY_ANDROID
            Log.Debug("创建新Android资源版本" + newVersionconfig.Version.ToString());
            type = PlatformType.Android;
    #elif UNITY_IOS
            Log.Debug("创建新iOS资源版本" + newVersionconfig.Version.ToString());
            type = PlatformType.IOS;
    #elif UNITY_WEBGL
            Log.Debug("创建新WEBGL资源版本" + newVersionconfig.Version.ToString());
            type = PlatformType.WebGL;
    #elif UNITY_STANDALONE_OSX
            Log.Debug("创建新Mac资源版本" + newVersionconfig.Version.ToString());
            type = PlatformType.MacOS;
    #else
            Log.Debug("创建新PC资源版本" + newVersionconfig.Version.ToString());
            type = PlatformType.PC;
    #endif

            //获取本地热更新文件目录地址
            string resFold = string.Format("../WebRes/{0}/StreamingAssets/", type);
            Log.Info($"============={resFold}===============");
            DirectoryInfo directoryInfo = new DirectoryInfo(resFold);
            if (directoryInfo.Exists)
            {
                long size = 0;
                //遍历本地文件 为每个文件建立一个FileVersionInfo
                FileInfo[] fileInfos = directoryInfo.GetFiles();
                foreach (FileInfo fileInfo in fileInfos)
                {
                    if (fileInfo.Name.EndsWith("meta"))
                    {
                        continue;
                    }
                    FileVersionInfo a = new FileVersionInfo();
                    a.File = fileInfo.Name;
                    a.MD5 = GetBundleMD5(fileInfo.Name,resFold);
                    a.Size = GetBundleSize(fileInfo.Name,resFold);
                    newVersionconfig.FileInfoDict.Add(fileInfo.Name, a);
                    size = a.Size + size;
                }

                //添加Version.txt到目录
                FileVersionInfo version = new FileVersionInfo();
                version.File = "Version.txt";
                version.MD5 = "";
                version.Size = 0;
                newVersionconfig.FileInfoDict.Add("Version.txt", version);
                newVersionconfig.TotalSize = size;

                //输出为文件
                string path = resFold + "/Version.txt";
                using (FileStream fs = new FileStream(path, FileMode.Create))
                {
                    byte[] data = System.Text.Encoding.ASCII.GetBytes(JsonHelper.ToJson(newVersionconfig));
                    fs.Write(data, 0, data.Length);
                }
            }
            else
            {
                Log.Error("热更新目录不存在");
            }
        }
    }
}