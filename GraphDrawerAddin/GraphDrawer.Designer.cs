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
            this.tabGrapX = this.Factory.CreateRibbonTab();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.expressionEditBox = this.Factory.CreateRibbonEditBox();
            this.variableEditBox = this.Factory.CreateRibbonEditBox();
            this.graphGeneratorButton = this.Factory.CreateRibbonButton();
            this.group2 = this.Factory.CreateRibbonGroup();
            this.xAxisBoundary = this.Factory.CreateRibbonEditBox();
            this.yAxisBoundary = this.Factory.CreateRibbonEditBox();
            this.yBoundaryAutoCheckBox = this.Factory.CreateRibbonCheckBox();
            this.separator2 = this.Factory.CreateRibbonSeparator();
            this.zoomSize = this.Factory.CreateRibbonEditBox();
            this.precision = this.Factory.CreateRibbonEditBox();
            this.isDrawCoordinateCheckBox = this.Factory.CreateRibbonCheckBox();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.drawDerivative = this.Factory.CreateRibbonButton();
            this.integralConstant = this.Factory.CreateRibbonEditBox();
            this.drawIntegral = this.Factory.CreateRibbonButton();
            this.tabGrapX.SuspendLayout();
            this.group1.SuspendLayout();
            this.group2.SuspendLayout();
            this.group3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabGrapX
            // 
            this.tabGrapX.Groups.Add(this.group1);
            this.tabGrapX.Groups.Add(this.group2);
            this.tabGrapX.Groups.Add(this.group3);
            this.tabGrapX.Label = "GrapX-Addin";
            this.tabGrapX.Name = "tabGrapX";
            // 
            // group1
            // 
            this.group1.Items.Add(this.expressionEditBox);
            this.group1.Items.Add(this.variableEditBox);
            this.group1.Items.Add(this.graphGeneratorButton);
            this.group1.Label = "그래프 생성";
            this.group1.Name = "group1";
            // 
            // expressionEditBox
            // 
            this.expressionEditBox.Label = "수식";
            this.expressionEditBox.Name = "expressionEditBox";
            this.expressionEditBox.Text = "x";
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
            this.graphGeneratorButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.GraphGeneratorButton_Click);
            // 
            // group2
            // 
            this.group2.Items.Add(this.xAxisBoundary);
            this.group2.Items.Add(this.yAxisBoundary);
            this.group2.Items.Add(this.yBoundaryAutoCheckBox);
            this.group2.Items.Add(this.separator2);
            this.group2.Items.Add(this.zoomSize);
            this.group2.Items.Add(this.precision);
            this.group2.Items.Add(this.isDrawCoordinateCheckBox);
            this.group2.Label = "그래프 옵션";
            this.group2.Name = "group2";
            // 
            // xAxisBoundary
            // 
            this.xAxisBoundary.Label = "가로축 범위";
            this.xAxisBoundary.Name = "xAxisBoundary";
            this.xAxisBoundary.Text = "-2, 2";
            // 
            // yAxisBoundary
            // 
            this.yAxisBoundary.Label = "세로축 범위";
            this.yAxisBoundary.Name = "yAxisBoundary";
            this.yAxisBoundary.Text = "-2, 2";
            // 
            // yBoundaryAutoCheckBox
            // 
            this.yBoundaryAutoCheckBox.Enabled = false;
            this.yBoundaryAutoCheckBox.Label = "세로축 범위 자동 설정";
            this.yBoundaryAutoCheckBox.Name = "yBoundaryAutoCheckBox";
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            // 
            // zoomSize
            // 
            this.zoomSize.Label = "확대/축소(%)";
            this.zoomSize.Name = "zoomSize";
            this.zoomSize.Text = "100";
            // 
            // precision
            // 
            this.precision.Label = "정밀도";
            this.precision.Name = "precision";
            this.precision.Text = "50";
            // 
            // isDrawCoordinateCheckBox
            // 
            this.isDrawCoordinateCheckBox.Checked = true;
            this.isDrawCoordinateCheckBox.Label = "좌표평면 그리기";
            this.isDrawCoordinateCheckBox.Name = "isDrawCoordinateCheckBox";
            this.isDrawCoordinateCheckBox.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.checkBox1_Click);
            // 
            // group3
            // 
            this.group3.Items.Add(this.drawDerivative);
            this.group3.Items.Add(this.integralConstant);
            this.group3.Items.Add(this.drawIntegral);
            this.group3.Label = "실험실";
            this.group3.Name = "group3";
            // 
            // drawDerivative
            // 
            this.drawDerivative.Label = "미분 함수 그리기";
            this.drawDerivative.Name = "drawDerivative";
            this.drawDerivative.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.DrawDerivative_Click);
            // 
            // integralConstant
            // 
            this.integralConstant.Label = "적분 상수";
            this.integralConstant.Name = "integralConstant";
            this.integralConstant.Text = "0";
            // 
            // drawIntegral
            // 
            this.drawIntegral.Label = "적분 함수 그리기";
            this.drawIntegral.Name = "drawIntegral";
            this.drawIntegral.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.DrawIntegral_Click);
            // 
            // GraphDrawer
            // 
            this.Name = "GraphDrawer";
            this.RibbonType = "Microsoft.PowerPoint.Presentation";
            this.Tabs.Add(this.tabGrapX);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.GraphDrawer_Load);
            this.tabGrapX.ResumeLayout(false);
            this.tabGrapX.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        internal Microsoft.Office.Tools.Ribbon.RibbonTab tabGrapX;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group1;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox expressionEditBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox variableEditBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton graphGeneratorButton;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group2;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox xAxisBoundary;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox yAxisBoundary;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox yBoundaryAutoCheckBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator2;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox zoomSize;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox precision;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton drawDerivative;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox integralConstant;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton drawIntegral;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox isDrawCoordinateCheckBox;
    }

    partial class ThisRibbonCollection
    {
        internal GraphDrawer GraphDrawer
        {
            get { return this.GetRibbon<GraphDrawer>(); }
        }
    }
}
