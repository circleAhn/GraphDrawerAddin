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
            this.group2 = this.Factory.CreateRibbonGroup();
            this.xAxisBoundary = this.Factory.CreateRibbonEditBox();
            this.yAxisBoundary = this.Factory.CreateRibbonEditBox();
            this.isYBoundaryAutoCheckBox = this.Factory.CreateRibbonCheckBox();
            this.separator2 = this.Factory.CreateRibbonSeparator();
            this.zoomSize = this.Factory.CreateRibbonEditBox();
            this.precision = this.Factory.CreateRibbonEditBox();
            this.isDrawCoordinateCheckBox = this.Factory.CreateRibbonCheckBox();
            this.group1 = this.Factory.CreateRibbonGroup();
            this.expressionEditBox = this.Factory.CreateRibbonEditBox();
            this.variableEditBox = this.Factory.CreateRibbonEditBox();
            this.graphGeneratorButton = this.Factory.CreateRibbonButton();
            this.group3 = this.Factory.CreateRibbonGroup();
            this.drawDerivative = this.Factory.CreateRibbonButton();
            this.drawIntegral = this.Factory.CreateRibbonButton();
            this.integralConstant = this.Factory.CreateRibbonEditBox();
            this.isPresentRoot = this.Factory.CreateRibbonCheckBox();
            this.separator1 = this.Factory.CreateRibbonSeparator();
            this.dotCoordinate = this.Factory.CreateRibbonEditBox();
            this.isContainsDotLineCheckBox = this.Factory.CreateRibbonCheckBox();
            this.isAlsoDrawDotCheckBox = this.Factory.CreateRibbonCheckBox();
            this.drawDot = this.Factory.CreateRibbonButton();
            this.drawTangent = this.Factory.CreateRibbonButton();
            this.separator3 = this.Factory.CreateRibbonSeparator();
            this.button2 = this.Factory.CreateRibbonButton();
            this.button3 = this.Factory.CreateRibbonButton();
            this.button4 = this.Factory.CreateRibbonButton();
            this.group4 = this.Factory.CreateRibbonGroup();
            this.installFonts = this.Factory.CreateRibbonButton();
            this.button1 = this.Factory.CreateRibbonButton();
            this.tabGrapX.SuspendLayout();
            this.group2.SuspendLayout();
            this.group1.SuspendLayout();
            this.group3.SuspendLayout();
            this.group4.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabGrapX
            // 
            this.tabGrapX.Groups.Add(this.group2);
            this.tabGrapX.Groups.Add(this.group1);
            this.tabGrapX.Groups.Add(this.group3);
            this.tabGrapX.Groups.Add(this.group4);
            this.tabGrapX.Label = "GrapX-Addin_v1";
            this.tabGrapX.Name = "tabGrapX";
            // 
            // group2
            // 
            this.group2.Items.Add(this.xAxisBoundary);
            this.group2.Items.Add(this.yAxisBoundary);
            this.group2.Items.Add(this.isYBoundaryAutoCheckBox);
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
            this.xAxisBoundary.ScreenTip = "좌표평면에 그려질 가로축 범위를 지정합니다.";
            this.xAxisBoundary.SuperTip = "a, b의 형식으로 범위를 작성해야 합니다. ex) -2, 4";
            this.xAxisBoundary.Text = "-2, 2";
            // 
            // yAxisBoundary
            // 
            this.yAxisBoundary.Label = "세로축 범위";
            this.yAxisBoundary.Name = "yAxisBoundary";
            this.yAxisBoundary.ScreenTip = "좌표평면에 그려질 세로축 범위를 지정합니다.";
            this.yAxisBoundary.SuperTip = "a, b의 형식으로 범위를 작성해야 합니다. ex) -2, 4";
            this.yAxisBoundary.Text = "-2, 2";
            // 
            // isYBoundaryAutoCheckBox
            // 
            this.isYBoundaryAutoCheckBox.Label = "세로 범위를 가로와 같게";
            this.isYBoundaryAutoCheckBox.Name = "isYBoundaryAutoCheckBox";
            this.isYBoundaryAutoCheckBox.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.yBoundaryAutoCheckBox_Click);
            // 
            // separator2
            // 
            this.separator2.Name = "separator2";
            // 
            // zoomSize
            // 
            this.zoomSize.Label = "확대/축소(%)";
            this.zoomSize.Name = "zoomSize";
            this.zoomSize.ScreenTip = "그래프의 크기를 지정합니다.";
            this.zoomSize.SuperTip = "50-200의 범위가 가능하며 입력 단위는 %입니다.";
            this.zoomSize.Text = "100";
            // 
            // precision
            // 
            this.precision.Label = "정밀도";
            this.precision.Name = "precision";
            this.precision.ScreenTip = "그래프의 정확도를 지정합니다.";
            this.precision.SuperTip = "숫자가 커질수록 계산 시간이 늘어나고 그래프의 정확성이 높아집니다. 100 이하의 숫자를 권장합니다.";
            this.precision.Text = "50";
            // 
            // isDrawCoordinateCheckBox
            // 
            this.isDrawCoordinateCheckBox.Checked = true;
            this.isDrawCoordinateCheckBox.Label = "좌표평면 그리기";
            this.isDrawCoordinateCheckBox.Name = "isDrawCoordinateCheckBox";
            this.isDrawCoordinateCheckBox.ScreenTip = "좌표평면(x축, y축, 원점, x, y 표시)을 그립니다.";
            this.isDrawCoordinateCheckBox.SuperTip = "그래프를 그릴 때 좌표평면을 표시합니다. 체크를 해제하면 좌표평면이 표시되지 않고 그래프만 표시됩니다.";
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
            this.expressionEditBox.OfficeImageId = "EquationFunctionGallery";
            this.expressionEditBox.ScreenTip = "그래프를 그리고자 할 수식 기호를 입력합니다.";
            this.expressionEditBox.ShowImage = true;
            this.expressionEditBox.SuperTip = "입력 가능한 연산자는 다음과 같습니다. cos(), sin(), tan(), sqrt(), log(), ln(), +, -, *, /, ^ 연산자" +
    "를 지원합니다. 일부 경우 *와 ^는 생략할 수 있습니다. 형식이 바르지 않으면 그래프가 그려지지 않고 오류가 반환됩니다.";
            this.expressionEditBox.Text = "x^2+x^3+sin(x)";
            // 
            // variableEditBox
            // 
            this.variableEditBox.Enabled = false;
            this.variableEditBox.Label = "변수";
            this.variableEditBox.Name = "variableEditBox";
            this.variableEditBox.OfficeImageId = "EquationNormalText";
            this.variableEditBox.ShowImage = true;
            this.variableEditBox.SuperTip = "변수는 현재 단일 변수만 지원하며, 수식에 사용되는 변수와 같아야 합니다.";
            this.variableEditBox.Text = "x";
            // 
            // graphGeneratorButton
            // 
            this.graphGeneratorButton.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.graphGeneratorButton.Label = "그래프 그리기";
            this.graphGeneratorButton.Name = "graphGeneratorButton";
            this.graphGeneratorButton.OfficeImageId = "InkEquation";
            this.graphGeneratorButton.ScreenTip = "수식에 맞는 그래프를 생성합니다.";
            this.graphGeneratorButton.ShowImage = true;
            this.graphGeneratorButton.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.GraphGeneratorButton_Click);
            // 
            // group3
            // 
            this.group3.Items.Add(this.drawDerivative);
            this.group3.Items.Add(this.drawIntegral);
            this.group3.Items.Add(this.integralConstant);
            this.group3.Items.Add(this.isPresentRoot);
            this.group3.Items.Add(this.separator1);
            this.group3.Items.Add(this.dotCoordinate);
            this.group3.Items.Add(this.isContainsDotLineCheckBox);
            this.group3.Items.Add(this.isAlsoDrawDotCheckBox);
            this.group3.Items.Add(this.drawDot);
            this.group3.Items.Add(this.drawTangent);
            this.group3.Items.Add(this.separator3);
            this.group3.Items.Add(this.button2);
            this.group3.Items.Add(this.button3);
            this.group3.Items.Add(this.button4);
            this.group3.Label = "실험실";
            this.group3.Name = "group3";
            // 
            // drawDerivative
            // 
            this.drawDerivative.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.drawDerivative.Label = "미분 함수 그리기";
            this.drawDerivative.Name = "drawDerivative";
            this.drawDerivative.OfficeImageId = "EquationSymbolsInsertGallery";
            this.drawDerivative.ScreenTip = "수식을 자동 미분하여 그래프를 생성합니다.";
            this.drawDerivative.ShowImage = true;
            this.drawDerivative.SuperTip = "주어진 수식을 자동으로 미분하여 미분된 함수의 그래프를 그립니다. 일부 함수는 계산이 불가할 수 있습니다.";
            this.drawDerivative.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.DrawDerivative_Click);
            // 
            // drawIntegral
            // 
            this.drawIntegral.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.drawIntegral.Label = "적분 함수 그리기";
            this.drawIntegral.Name = "drawIntegral";
            this.drawIntegral.OfficeImageId = "EquationSymbolsInsertGallery";
            this.drawIntegral.ScreenTip = "수식을 자동 적분하여 그래프를 생성합니다.";
            this.drawIntegral.ShowImage = true;
            this.drawIntegral.SuperTip = "주어진 수식을 자동으로 적분하여 적분된 함수와 적분 상수를 바탕으로 그래프를 그립니다. 일부 함수는 계산이 불가할 수 있습니다.";
            this.drawIntegral.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.DrawIntegral_Click);
            // 
            // integralConstant
            // 
            this.integralConstant.Label = "적분 상수";
            this.integralConstant.Name = "integralConstant";
            this.integralConstant.Text = "0";
            // 
            // isPresentRoot
            // 
            this.isPresentRoot.Enabled = false;
            this.isPresentRoot.Label = "함수 절편 표시";
            this.isPresentRoot.Name = "isPresentRoot";
            // 
            // separator1
            // 
            this.separator1.Name = "separator1";
            // 
            // dotCoordinate
            // 
            this.dotCoordinate.Label = "점 좌표";
            this.dotCoordinate.Name = "dotCoordinate";
            this.dotCoordinate.ScreenTip = "좌표평면에 찍을 점의 좌표를 지정합니다.";
            this.dotCoordinate.SuperTip = "a, b의 형식으로 범위를 작성해야 합니다. ex) -2, 4";
            this.dotCoordinate.Text = "-1, 1";
            // 
            // isContainsDotLineCheckBox
            // 
            this.isContainsDotLineCheckBox.Checked = true;
            this.isContainsDotLineCheckBox.Label = "점선 포함";
            this.isContainsDotLineCheckBox.Name = "isContainsDotLineCheckBox";
            this.isContainsDotLineCheckBox.SuperTip = "점의 위치를 점선으로 표시합니다.";
            // 
            // isAlsoDrawDotCheckBox
            // 
            this.isAlsoDrawDotCheckBox.Label = "접선 그을때 점 찍기";
            this.isAlsoDrawDotCheckBox.Name = "isAlsoDrawDotCheckBox";
            // 
            // drawDot
            // 
            this.drawDot.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.drawDot.Label = "점 찍기";
            this.drawDot.Name = "drawDot";
            this.drawDot.OfficeImageId = "EquationSymbolsInsertGallery";
            this.drawDot.ShowImage = true;
            this.drawDot.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.DrawDot_Click);
            // 
            // drawTangent
            // 
            this.drawTangent.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.drawTangent.Label = "접선 긋기";
            this.drawTangent.Name = "drawTangent";
            this.drawTangent.OfficeImageId = "EquationSymbolsInsertGallery";
            this.drawTangent.ShowImage = true;
            this.drawTangent.SuperTip = "좌표를 접점으로 하는 접선을 그립니다. 해당 점이 접점이 아닌 경우 그려지지 않습니다.";
            this.drawTangent.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.DrawTangent_Click);
            // 
            // separator3
            // 
            this.separator3.Name = "separator3";
            // 
            // button2
            // 
            this.button2.Enabled = false;
            this.button2.Label = "함수 교점 자동 찾기";
            this.button2.Name = "button2";
            this.button2.OfficeImageId = "EquationSymbolsInsertGallery";
            this.button2.ShowImage = true;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.Label = "함수 수식 추출";
            this.button3.Name = "button3";
            this.button3.OfficeImageId = "EquationSymbolsInsertGallery";
            this.button3.ShowImage = true;
            // 
            // button4
            // 
            this.button4.Enabled = false;
            this.button4.Label = "분수 변환";
            this.button4.Name = "button4";
            this.button4.OfficeImageId = "EquationSymbolsInsertGallery";
            this.button4.ShowImage = true;
            // 
            // group4
            // 
            this.group4.Items.Add(this.installFonts);
            this.group4.Items.Add(this.button1);
            this.group4.Label = "기타";
            this.group4.Name = "group4";
            // 
            // installFonts
            // 
            this.installFonts.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.installFonts.Label = "폰트 설치";
            this.installFonts.Name = "installFonts";
            this.installFonts.OfficeImageId = "ThemeFontsGallery";
            this.installFonts.ScreenTip = "수식 전용 폰트(LM Roman체)를 설치합니다.";
            this.installFonts.ShowImage = true;
            this.installFonts.SuperTip = "수식 전용 폰트인 LM Roman체를 설치하면, 숫자나 기호 등을 실제 폰트와 유사하도록 수정할 수 있습니다.";
            this.installFonts.Click += new Microsoft.Office.Tools.Ribbon.RibbonControlEventHandler(this.InstallFonts_Click);
            // 
            // button1
            // 
            this.button1.ControlSize = Microsoft.Office.Core.RibbonControlSize.RibbonControlSizeLarge;
            this.button1.Label = "프로그램 리셋";
            this.button1.Name = "button1";
            this.button1.OfficeImageId = "Redo";
            this.button1.ShowImage = true;
            // 
            // GraphDrawer
            // 
            this.Name = "GraphDrawer";
            this.RibbonType = "Microsoft.PowerPoint.Presentation";
            this.Tabs.Add(this.tabGrapX);
            this.Load += new Microsoft.Office.Tools.Ribbon.RibbonUIEventHandler(this.GraphDrawer_Load);
            this.tabGrapX.ResumeLayout(false);
            this.tabGrapX.PerformLayout();
            this.group2.ResumeLayout(false);
            this.group2.PerformLayout();
            this.group1.ResumeLayout(false);
            this.group1.PerformLayout();
            this.group3.ResumeLayout(false);
            this.group3.PerformLayout();
            this.group4.ResumeLayout(false);
            this.group4.PerformLayout();
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
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox isYBoundaryAutoCheckBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator2;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox zoomSize;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox precision;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton drawDerivative;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox integralConstant;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton drawIntegral;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox isDrawCoordinateCheckBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox isPresentRoot;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton installFonts;
        internal Microsoft.Office.Tools.Ribbon.RibbonGroup group4;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button1;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator1;
        internal Microsoft.Office.Tools.Ribbon.RibbonEditBox dotCoordinate;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox isContainsDotLineCheckBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton drawDot;
        internal Microsoft.Office.Tools.Ribbon.RibbonSeparator separator3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button2;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button3;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton button4;
        internal Microsoft.Office.Tools.Ribbon.RibbonCheckBox isAlsoDrawDotCheckBox;
        internal Microsoft.Office.Tools.Ribbon.RibbonButton drawTangent;
    }

    partial class ThisRibbonCollection
    {
        internal GraphDrawer GraphDrawer
        {
            get { return this.GetRibbon<GraphDrawer>(); }
        }
    }
}
