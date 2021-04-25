using System.IO;
using System.Security.AccessControl;

namespace Sprd.UI.ViewModels
{
    public static class FileExtensions
    {
        public static bool HasWritePermissionOnDir(this string path)
        {
            var writeAllow = false;
            var writeDeny = false;

            var accessControlList = new FileInfo(path).Directory.GetAccessControl();
            if (accessControlList == null)
                return false;
            var accessRules = accessControlList.GetAccessRules(true, true,
                typeof(System.Security.Principal.SecurityIdentifier));
            if (accessRules == null)
                return false;

            foreach (FileSystemAccessRule rule in accessRules)
            {
                if ((FileSystemRights.Write & rule.FileSystemRights) != FileSystemRights.Write)
                    continue;

                if (rule.AccessControlType == AccessControlType.Allow)
                    writeAllow = true;
                else if (rule.AccessControlType == AccessControlType.Deny)
                    writeDeny = true;
            }

            return writeAllow && !writeDeny;
        }
    }
}