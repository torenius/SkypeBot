using SkypeBot.SkypeStuff;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Client.SkypeStuff
{
    public partial class SkypeControl : UserControl
    {
        private ISkypeHandler _skypeHandler;

        public SkypeControl()
        {
            InitializeComponent();

            //ChatListView
            ChatListView.View = View.Tile;
            ChatListView.FullRowSelect = true;
            ChatListView.MultiSelect = false;
            ChatListView.Sorting = SortOrder.Ascending;

            ChatListView.Columns.Add("ChatName", ChatListView.Width);
            ChatListView.Columns.Add("ChatCode", ChatListView.Width);

            //UserListView
            UserListView.View = View.Details;
            UserListView.FullRowSelect = true;
            UserListView.MultiSelect = false;
            UserListView.Sorting = SortOrder.Ascending;

            UserListView.Columns.Add("DisplayName", 200);
            UserListView.Columns.Add("Username", 100);

            //Läs in ikoner
            LoadSkypeIcons();

            MakeTextboxToLabel(NameBox);
            MakeTextboxToLabel(CodeBox);
            MakeTextboxToLabel(CountBox);
            Refresh();
        }

        /// <summary>
        /// Talar om varifrån som koden ska hämta information
        /// </summary>
        /// <param name="skypeHandler"></param>
        public void SetSkypeHandler(ISkypeHandler skypeHandler)
        {
            _skypeHandler = skypeHandler;
            PopulateChatListView();
        }

        /// <summary>
        /// Gör om en textbox till att se ut som en label.
        /// Anledningen är att det inte går att markera text när man har en label.
        /// </summary>
        /// <param name="tb">Textbox som ska förvandlas till label</param>
        private void MakeTextboxToLabel(TextBox tb)
        {
            tb.ReadOnly = true;
            tb.BorderStyle = 0;
            tb.BackColor = SystemColors.Window;
            tb.TabStop = false;
        }

        /// <summary>
        /// Försöker ladda alla SkypeIconerna.
        /// </summary>
        private void LoadSkypeIcons()
        {
            ImageList skypeIcons = new ImageList();
            ImageList skypeIconsLarge = new ImageList();

            //SmallIcons
            try { skypeIcons.Images.Add("Away", Image.FromFile("SkypeIcons\\Skype_Away.png")); }
            catch { }
            try { skypeIcons.Images.Add("Chat", Image.FromFile("SkypeIcons\\Skype_Chat.png")); }
            catch { }
            try { skypeIcons.Images.Add("DND", Image.FromFile("SkypeIcons\\Skype_Dnd.png")); }
            catch { }
            try { skypeIcons.Images.Add("Invisible", Image.FromFile("SkypeIcons\\Skype_Invisible.png")); }
            catch { }
            try { skypeIcons.Images.Add("Offline", Image.FromFile("SkypeIcons\\Skype_Offline.png")); }
            catch { }
            try { skypeIcons.Images.Add("Online", Image.FromFile("SkypeIcons\\Skype_Online.png")); }
            catch { }
            try { skypeIcons.Images.Add("Unknown", Image.FromFile("SkypeIcons\\Skype_Unknown.png")); }
            catch { }

            //LargeIcons
            try { skypeIconsLarge.Images.Add("Away", Image.FromFile("SkypeIcons\\Skype_Away_Large.png")); }
            catch { }
            try { skypeIconsLarge.Images.Add("Chat", Image.FromFile("SkypeIcons\\Skype_Chat_Large.png")); }
            catch { }
            try { skypeIconsLarge.Images.Add("DND", Image.FromFile("SkypeIcons\\Skype_Dnd_Large.png")); }
            catch { }
            try { skypeIconsLarge.Images.Add("Invisible", Image.FromFile("SkypeIcons\\Skype_Invisible_Large.png")); }
            catch { }
            try { skypeIconsLarge.Images.Add("Offline", Image.FromFile("SkypeIcons\\Skype_Offline_Large.png")); }
            catch { }
            try { skypeIconsLarge.Images.Add("Online", Image.FromFile("SkypeIcons\\Skype_Online_Large.png")); }
            catch { }
            try { skypeIconsLarge.Images.Add("Unknown", Image.FromFile("SkypeIcons\\Skype_Unknown_Large.png")); }
            catch { }

            ChatListView.SmallImageList = skypeIcons;
            ChatListView.LargeImageList = skypeIconsLarge;

            UserListView.SmallImageList = skypeIcons;
            UserListView.LargeImageList = skypeIconsLarge;
        }

        /// <summary>
        /// Fyller chatListView med information om vilka chater som är aktiva.
        /// </summary>
        public void PopulateChatListView()
        {
            if (_skypeHandler == null) return;

            Console.WriteLine("populate chat");
            ChatListView.Items.Clear();

            foreach (ChatInfo ci in _skypeHandler.GetActiveChats())
            {
                ListViewItem item = new ListViewItem(ci.ChatName, ci.ChatStatusIcon);
                item.SubItems.Add(ci.LastActive.ToString());
                ChatListView.Items.Add(item);
            }

            ChatListView.Refresh();
        }

        /// <summary>
        /// Händer när någon klickar på ett object i ChatListView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ChatListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ChatListView.SelectedItems.Count > 0)
            {
                ListViewItem item = ChatListView.SelectedItems[0];

                ChatInfo ci = _skypeHandler.GetChatInfo(item.SubItems[0].Text);

                PopulateUserListView(ci);
            }
        }

        /// <summary>
        /// Fyller listan med användare som finns i chatten.
        /// </summary>
        /// <param name="ci"></param>
        private void PopulateUserListView(ChatInfo ci)
        {
            UserListView.Items.Clear();

            if (ci == null) return;

            NameBox.Text = ci.ChatName;
            CodeBox.Text = ci.ChatCode;
            CountBox.Text = "" + ci.UserList.Count;

            foreach (UserInfo ui in ci.UserList)
            {
                ListViewItem item = new ListViewItem(ui.DisplayName, ui.StatusIcon);
                item.SubItems.Add(ui.Username);
                UserListView.Items.Add(item);
            }
        }
    }
}
