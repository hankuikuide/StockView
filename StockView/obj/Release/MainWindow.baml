   M S B A M L   `   `   `  ���� D  @StockView, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:StockView	StockView      StockView.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     )localclr-namespace:StockView       � Title$  股价查看器��$��275.431��$��400.431�� � 	Resources   StockView.ColorConverter   ColorConverter��%   &	          .��� .+�&   System.Windows.Controls.DataGrid  -     Name$ 	StockGrid��   AutoGenerateColumns .     Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ 股票代码��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *Symbol+  $ 股票名称�� �� *Name+  $ 现价�� �� *Price+  $ 涨幅�� �� *
Increase+  $ 	开盘价�� �� *Open+  $ 昨收�� �� *	PrevClose+4  .System.Windows.Controls.DataGridTemplateColumn  $ 最新��   CellTemplate �� .R��� $��Center=����� *Price+��`�  `� 	Converter# [  	 `� ConverterParameter$	 FormatLastFirst��.1��� 
 �� Path$
 Price��� $
 	PrevClose�   RowStyle ��  �� 
TargetType)  #System.Windows.Controls.DataGridRow"  .���  �� Property � �� �� Value
 �   ���  � ��
 ����� �� Triggers P�  P� Property �@J�IsMouseOver P� Value . . ���  � ��
 �  ��P�  �@ 
IsSelected . . ���  � ��
 �������  � ��
 �  ��