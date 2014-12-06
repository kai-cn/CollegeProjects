<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Left.ascx.cs" Inherits="admin_UC_Left" %>
<script src="../../js/prototype.lite.js" type="text/javascript"></script>
<script src="../../js/moo.fx.js" type="text/javascript"></script>
<script src="../../js/moo.fx.pack.js" type="text/javascript"></script>
<style>
body {
	font:14px Arial, Helvetica, sans-serif;
	color: #000;
	background-color: #EEF2FB;
	margin: 0px;
}
#container {
	width: 182px;
}
H1 {
	font-size: 12px;
	margin: 0px;
	width: 182px;
	cursor: pointer;
	height: 30px;
	line-height: 20px;	
}
H1 a {
	display: block;
	width: 182px;
	color: #000;
	height: 30px;
	text-decoration: none;
	moz-outline-style: none;
	background-image: url(images/menu_bgS.gif);
	background-repeat: no-repeat;
	line-height: 30px;
	text-align: center;
	margin: 0px;
	padding: 0px;
}
.content{
	width: 182px;
	height: 26px;
	
}
.MM ul {
	list-style-type: none;
	margin: 0px;
	padding: 0px;
	display: block;
}
.MM li {
	font-family: Arial, Helvetica, sans-serif;
	font-size: 12px;
	line-height: 26px;
	color: #333333;
	list-style-type: none;
	display: block;
	text-decoration: none;
	height: 26px;
	width: 182px;
	padding-left: 0px;
}
.MM {
	width: 182px;
	margin: 0px;
	padding: 0px;
	left: 0px;
	top: 0px;
	right: 0px;
	bottom: 0px;
	clip: rect(0px,0px,0px,0px);
}
.MM a:link {
	font-family: Arial, Helvetica, sans-serif;
	font-size: 12px;
	line-height: 26px;
	color: #333333;
	background-image: url(images/menu_bg1.gif);
	background-repeat: no-repeat;
	height: 26px;
	width: 182px;
	display: block;
	text-align: center;
	margin: 0px;
	padding: 0px;
	overflow: hidden;
	text-decoration: none;
}
.MM a:visited {
	font-family: Arial, Helvetica, sans-serif;
	font-size: 12px;
	line-height: 26px;
	color: #333333;
	background-image: url(images/menu_bg1.gif);
	background-repeat: no-repeat;
	display: block;
	text-align: center;
	margin: 0px;
	padding: 0px;
	height: 26px;
	width: 182px;
	text-decoration: none;
}
.MM a:active {
	font-family: Arial, Helvetica, sans-serif;
	font-size: 12px;
	line-height: 26px;
	color: #333333;
	background-image: url(images/menu_bg1.gif);
	background-repeat: no-repeat;
	height: 26px;
	width: 182px;
	display: block;
	text-align: center;
	margin: 0px;
	padding: 0px;
	overflow: hidden;
	text-decoration: none;
}
.MM a:hover {
	font-family: Arial, Helvetica, sans-serif;
	font-size: 12px;
	line-height: 26px;
	font-weight: bold;
	color: #006600;
	background-image: url(images/menu_bg2.gif);
	background-repeat: no-repeat;
	text-align: center;
	display: block;
	margin: 0px;
	padding: 0px;
	height: 26px;
	width: 182px;
	text-decoration: none;
}
</style>

<%--<table width="100%" height="280" border="0" cellpadding="0" cellspacing="0" bgcolor="#EEF2FB">
  <tr>
    <td width="182" valign="top"><div id="container">
      <h1 class="type"><a href="javascript:void(0)">接待工作安排</a></h1>
      <div class="content">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td><img src="images/menu_topline.gif" width="182" height="5" /></td>
          </tr>
        </table>
        <ul class="MM">
          <li><a href="/admin/rec/rec_list.aspx?type=1" target="main">兄弟院校来访</a></li>
          <li><a href="/admin/rec/rec_list.aspx?type=2" target="main">领导指导工作</a></li>
          <li><a href="/admin/rec/rec_list.aspx?type=3" target="main">重大活动安排</a></li>
          <li><a target="main" href="">接待规则</a></li>

        </ul>
      </div>
      <h1 class="type"><a href="javascript:void(0)">财务报销系统</a></h1>
      <div class="content">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td><img src="images/menu_topline.gif" width="182" height="5" /></td>
          </tr>
        </table>
        <ul class="MM">
          <li><a href="/admin/finance/merchant_list.aspx?type=1" target="main">宴请报销</a></li>
          <li><a href="/admin/finance/merchant_list.aspx?type=2" target="main">住宿报销</a></li>
          <li><a href="/admin/finance/merchant_list.aspx?type=3" target="main">礼品报销</a></li>
          
        </ul>
      </div>
      <h1 class="type"><a href="javascript:void(0)">基本信息</a></h1>
      <div class="content">
        <table width="100%" border="0" cellspacing="0" cellpadding="0">
          <tr>
            <td><img src="images/menu_topline.gif" width="182" height="5" /></td>
          </tr>
        </table>
        <ul class="MM">
		  <li><a href="/admin/leader_type.aspx" target="main">领导个人信息</a></li>
          <li><a href="/admin/uni_contact/Default.aspx" target="main">高校联系方式</a></li>
          <li><a  target="main" href="">合作单位</a></li>
        </ul>
      </div>
      <h1 class="type"><a href="../logout.aspx">安全退出</a></h1>
      
    </div>
        <script type="text/javascript">
            var contents = document.getElementsByClassName('content');
            var toggles = document.getElementsByClassName('type');

            var myAccordion = new fx.Accordion(
			toggles, contents, { opacity: true, duration: 400 }
		);
            myAccordion.showThisHideOpen(contents[0]);
	</script>
        </td>
  </tr>
</table>--%>

<table>
    <tr>
        <td width="25px">&nbsp;</td>
        <td width="200px">
    <asp:TreeView ID="TVLeft" runat="server" ShowLines="True" Width="200px" NodeStyle-Height="30px">
        <Nodes>
            <asp:TreeNode Expanded="True" Text="日常接待" NavigateUrl="~/admin/rec/rec_list.aspx" Value="接待工作安排">
                <asp:TreeNode Text="兄弟院校来访" Value="兄弟院校来访" NavigateUrl="~/admin/rec/rec_list.aspx?type=1"></asp:TreeNode>
                <asp:TreeNode Text="领导指导工作" Value="领导指导工作" NavigateUrl="~/admin/rec/rec_list.aspx?type=2"></asp:TreeNode>
                <asp:TreeNode Text="重大活动安排" Value="重大活动安排" NavigateUrl="~/admin/rec/rec_list.aspx?type=3"></asp:TreeNode>
               
            </asp:TreeNode>
            <asp:TreeNode Expanded="True" Text="报销明细" NavigateUrl="~/admin/finance/finance_stat.aspx" Value="财务报销系统">
                <asp:TreeNode Text="宴请住宿报销" Value="宴请报销" NavigateUrl="~/admin/finance/finance_stat.aspx?type=1"></asp:TreeNode>
                <asp:TreeNode Text="礼品报销" Value="礼品报销" NavigateUrl="~/admin/finance/finance_stat.aspx?type=3"></asp:TreeNode>
            </asp:TreeNode>
            <asp:TreeNode Expanded="True" Text="基本信息" Value="基本信息">
              
                                    <asp:TreeNode Text="合作单位" Value="合作单位" NavigateUrl="~/admin/coop/coop_type.aspx"></asp:TreeNode>
                <asp:TreeNode Text="高校联系方式" NavigateUrl="~/admin/uni_contact/Default.aspx" Value="高校联系方式"></asp:TreeNode>
                 <asp:TreeNode Text="接待规则" Value="接待规则" NavigateUrl="~/admin/rec/rec_ruleList.aspx"></asp:TreeNode>
                   <asp:TreeNode Text="酒店协议" Value="酒店协议" NavigateUrl="~/admin/protocol/protocol_type.aspx"></asp:TreeNode>
                    <asp:TreeNode Text="部门和院校" Value="部门和院校" NavigateUrl="~/admin/department/department_type.aspx"></asp:TreeNode>
            </asp:TreeNode>
            <asp:TreeNode Text="重要信息">
              <asp:TreeNode Text="领导个人信息" Value="领导个人信息" 
                    NavigateUrl="~/admin/leader_type.aspx"></asp:TreeNode>
                    </asp:TreeNode>
            <asp:TreeNode NavigateUrl="~/admin/logout.aspx" Text="安全退出" Value="安全退出">
            </asp:TreeNode>
        </Nodes>
    </asp:TreeView>        
        </td>
        <td width="25px">&nbsp;</td>
    </tr>
</table>
