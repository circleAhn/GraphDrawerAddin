namespace GraphDrawerAddin
{
    partial class GraphDrawer : Microsoft.Office.Tools.Ribbon.RibbonBase
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        public GraphDrawer()
            : base(Globals.Factory.GetRibbonFactory())
        {
            InitializeComponent();
        }

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.tab2 = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.expressionEditBox = this.Factory.CreateRibbonEditBox();
            this.variableEditBox = this.Factory.CreateRibbonEditBox();
            this.button1 = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.editBox3 = this.Factory.CreateRibbonEditBox();
            this.editBox4 = this.Factory.CreateRibbonEditBox();
            this.checkBox2 = this.Factory.CreateRibbonCheckBox();
            this.separator2 = this.Factory.CreateRibbonSeparator();
            this.editBox5 = this.Factory.CreateRibbonEditBox();
            this.editBox6 = this.Factory.CreateRibbonEditBox();
            this.checkBox3 = this.Factory.CreateRibbonCheckBox();
            this.tab2.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab2
            // 
            this.tab2.Groups.Add(this.group1);
            this.tab2.Groups.Add(this.group2);
            this.tab2.Label = "GrapX";
            this.tab2.Name = "tab2";
            // 
            // group1
            // 
            this.group1.Items.Add(this.expressionEditBox);
            this.group1.Items.Add(this.variableEditBox);
            this.group1.Items.Add(this.button1);
            this.group1.Label = "그래프 생성";
            this.group1.Name = "group1";
            // 
            // expressionEditBox
            // 
            this.expressionEditBox.Label = "수식";
            this.expressionEditBox.Name = "expressionEditBox";
            this.expressionEditBox.Text = null;
            // 
            // variableEditBox
            // 
            this.variableEditBox.Label = "변수";
            this.variableEditBox.Name = "variableEditBox";
            this.variableEditBox.Text = "x";
            // 
            // button1
            // 
            this.button1.Label = "생성하기";
            this.button1.Name = "button1";
            // 
            // group2
            // 
            this.group2.Items.Add(this.editBox3);
            this.group2.Items.Add(this.editBox4);
            this.group2.Items.Add(this.checkBox2);
            this.group2.Items.Add(this.separator2);
            this.group2.Items.Add(this.editBox5);
            this.group2.Items.Add(this.editBox6);
            this.group2.Items.Add(this.checkBox3);
            this.group2.Label = "그래프 옵션";
            this.group2.Name = "group2";
            // 
            // editBox3
            // 
            this.editBox3.Label = "가로축 범위";
            this.editBox3.Name = "editBox3";
            this.editBox3.Text = "-2, 2";
            // 
            // editBox4
            // 
            this.editBox4.Label = "세로축 범위";
            this.editBox4.Name = "editBox4";
            this.editBox4.Text = "-2, 2";
            // 
            // checkBox2
            // 
            this.checkBox2.Label = "세로축 범위 자동 설정";
            this.checkBox2.Name = "checkBox2";
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            // 
            // editBox5
            // 
            this.editBox5.Label = "가로길이 확대/축소(%)";
            this.editBox5.Name = "editBox5";
            this.editBox5.Text = "100";
            // 
            // editBox6
            // 
            this.editBox6.Label = "세로길이 확대/축소(%)";
            this.editBox6.Name = "editBox6";
            this.editBox6.Text = "100";
            // 
            // checkBox3
            // 
            this.checkBox3.Label = "상하좌우 비율 고정";
            this.checkBox3.Name = "checkBox3";
            // 
            // GraphDrawer
            // 
            this.Name = "GraphDrawer";
            this.RibbonType = "Microsoft.PowerPoint.Presentation";
            this.Tabs.Add(this.tab2);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.GraphDrawer_Load);
            this.tab2.ResumeLayout(false);
            this.tab2.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab2;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox expressionEditBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox variableEditBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBox3;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBox4;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox checkBox2;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator2;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBox5;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox editBox6;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox checkBox3;
    }

    partial class ThisRibbonCollection
    {
        internal GraphDrawer GraphDrawer
        {
            get { return this.GetRibbon<GraphDrawer>(); }
        }
    }
}
