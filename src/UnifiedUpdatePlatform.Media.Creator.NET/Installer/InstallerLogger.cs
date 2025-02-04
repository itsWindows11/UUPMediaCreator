﻿using UnifiedUpdatePlatform.Imaging.NET;

namespace UnifiedUpdatePlatform.Media.Creator.NET.Installer
{
    internal static class InstallerLogger
    {
        private static readonly Common.Messaging.Common.ProcessPhase Phase = Common.Messaging.Common.ProcessPhase.CreatingWindowsInstaller;

        internal static WimImaging.ProgressCallback GetImagingCallback(this ProgressCallback progressCallback)
        {
            return (Operation, ProgressPercentage, IsIndeterminate) => progressCallback?.Invoke(Phase, IsIndeterminate, ProgressPercentage, Operation);
        }

        internal static void Log(this ProgressCallback progressCallback, string Operation)
        {
            progressCallback.Invoke(Phase, true, 0, Operation);
        }

        internal static void Log(this ProgressCallback progressCallback, string Operation, int Progress)
        {
            progressCallback.Invoke(Phase, false, Progress, Operation);
        }
    }
}
