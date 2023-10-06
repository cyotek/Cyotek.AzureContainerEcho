// Cyotek Down Detector
// https://github.com/cyotek/CyotekDownDetector

// Copyright © 2021 Cyotek Ltd. All Rights Reserved.

// This work is licensed under the MIT License.
// See LICENSE.txt for the full text

// Found this example useful?
// https://www.paypal.me/cyotek

using System.Windows.Forms;

namespace Cyotek.AzureContainerEcho.Client
{
  internal class SettingsPanelBase : UserControl
  {
    #region Public Methods

    public virtual void LoadSettings(ContainerEchoSettings settings)
    {
    }

    public virtual void SaveSettings(ContainerEchoSettings settings)
    {
    }

    #endregion Public Methods
  }
}