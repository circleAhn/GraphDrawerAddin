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
            this.tab1 = this.Factory.CreateRibbonTab();
            this.graphGeneratorGruop = this.Factory.CreateRibbonGroup();
            this.expressionEditBox = this.Factory.CreateRibbonEditBox();
            this.variableEditBox = this.Factory.CreateRibbonEditBox();
            this.graphGeneratorButton = this.Factory.CreateRibbonButton();
            this.tab1.SuspendLayout();
            this.graphGeneratorGruop.SuspendLayout();
            this.SuspendLayout();
            // 
            // tab1
            // 
            this.tab1.ControlId.ControlIdType = Microsoft.Office.Tools.Ribbon.RibbonControlIdType.Office;
            this.tab1.Groups.Add(this.graphGeneratorGruop);
            this.tab1.Label = "TabAddIns";
            this.tab1.Name = "tab1";
            // 
            // graphGeneratorGruop
            // 
            this.graphGeneratorGruop.Items.Add(this.expressionEditBox);
            this.graphGeneratorGruop.Items.Add(this.variableEditBox);
            this.graphGeneratorGruop.Items.Add(this.graphGeneratorButton);
            this.graphGeneratorGruop.Label = "그래프 생성";
            this.graphGeneratorGruop.Name = "graphGeneratorGruop";
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
            // graphGeneratorButton
            // 
            this.graphGeneratorButton.Label = "생성하기";
            this.graphGeneratorButton.Name = "graphGeneratorButton";
            this.graphGeneratorButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.graphGeneratorButton_Click);
            // 
            // GraphDrawer
            // 
            this.Name = "GraphDrawer";
            this.RibbonType = "Microsoft.PowerPoint.Presentation";
            this.Tabs.Add(this.tab1);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.GraphDrawer_Load);
            this.tab1.ResumeLayout(false);
            this.tab1.PerformLayout();
            this.graphGeneratorGruop.ResumeLayout(false);
            this.graphGeneratorGruop.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tab1;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup graphGeneratorGruop;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox expressionEditBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton graphGeneratorButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox variableEditBox;
    }

    partial class ThisRibbonCollection
    {
        internal GraphDrawer GraphDrawer
        {
            get { return this.GetRibbon<GraphDrawer>(); }
        }
    }
}
