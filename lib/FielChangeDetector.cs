using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoalBar
{
    class FielChangeDetector
    {
        public static Dictionary<string, DateTime> fileTimeModificationCache = new Dictionary<string, DateTime>();

        public static bool changed(string filePath) {

            FileInfo fileInfo = new FileInfo(filePath);
            DateTime lastModified = fileInfo.LastWriteTime;

            if (!fileTimeModificationCache.ContainsKey(filePath)) {
                fileTimeModificationCache.Add(filePath, lastModified);
                return true;
            }

            DateTime prevModified = fileTimeModificationCache[filePath];

            if (prevModified != lastModified) {
                fileTimeModificationCache[filePath] = lastModified;
                return true;
            }

            return false;
        }
    }
}
