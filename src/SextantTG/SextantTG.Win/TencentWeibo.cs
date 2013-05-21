using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenTSDK.Tencent;
using OpenTSDK.Tencent.API;
using OpenTSDK.Tencent.Objects;
using System.Windows.Forms;
using System.Diagnostics;

namespace SextantTG.Win
{
    class TencentWeibo
    {
        private OAuth oauth;
        private string oaKeystr;
        private string oaSecretstr;

        public TencentWeibo()
        {
            AccessWeibo();
        }

        public void AccessWeibo()
        {
            oaKeystr = "801357962";
            oaSecretstr = "c5304799456eb5c11f0c3e30ee92723d";
            oauth = new OAuth(oaKeystr, oaSecretstr);
            //获取请求Token
            if (oauth.GetRequestToken(null))
            {
                Process.Start("https://open.t.qq.com/cgi-bin/authorize?oauth_token=" + oauth.Token);
                string verifier;
                string name;
                WeiboOauthForm oauthForm = new WeiboOauthForm();
                if (oauthForm.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                     verifier = oauthForm.GetOauthCode();
                     if (oauth.GetAccessToken(verifier, out name))
                     {
                         MessageBox.Show("获取Access Token成功,微博帐户名=" + name, "授权成功");
                     }
                     else
                     {
                         MessageBox.Show("获取Access Token时出错，错误信息：" + oauth.LastError, "授权失败");
                     }
                }          
            }
            else
            {
                MessageBox.Show("获取Access Token时出错，错误信息： " + oauth.LastError, "授权失败");
            }
            if (oauth.LastError != null)
            {
                return;
            }
        }

        public OAuth GetOAuth()
        {
            return oauth;
        }
    }
}
