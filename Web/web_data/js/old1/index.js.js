var infoPath = "realtime/data.json";
var maxDataLength = 200;
var updateInterval = 1000;
var maxDiffTime = 10000;

var dataSet = [];
var chart;

function loadInfoData() {
	$.getJSON(infoPath, function(data) {
		$.each(data, function(key, val) {
			var arr = [];
			var d = new Date();
			for(var i = 0; i < 200; i++) {
				arr.push({
					date: d,
					value: 0
				});
			}
			dataSet.push(arr);
		});
		initChart();
	});
}

function updateData() {
	if (chart.mouseDown) return;
	$.getJSON(infoPath, function(data) {
		var d = new Date();
		$.each(data, function(key, val) {
			dataSet[key].shift();
			var a1 = Math.round(Math.random() * (40 + key)) + 100 + key;
			chart.dataSets[key].dataProvider.push({
				date: d,
				value: val["power"] + a1
			});
			//console.log(d+  "  " +val["power"])
		});
		chart.validateData();
		
		var diffTime = chart.endDate.getTime() - chart.startDate.getTime();
		if(diffTime > maxDiffTime) {
			chart.zoom(new Date(d - maxDiffTime), d);
		} else {
			chart.zoom(chart.startDate, d);
		}
	});
}

function initChart() {
	var arr_ds = [];
	$.each(dataSet, function(key, val) {
		var ds = new AmCharts.DataSet();
		ds.title = (key == 0 ? "Tổng cộng" : "Mạch "+key);
		ds.fieldMappings = [
			{fromField: "value", toField: "value"}
		];
		ds.dataProvider = val;
		ds.categoryField = "date";
		arr_ds.push(ds);
	});
	
	chart = new AmCharts.AmStockChart();
	chart.dataSets = arr_ds;
	chart.mainDataSet = arr_ds[0];
	//chart.glueToTheEnd = true;
	
	var categoryAxesSettings = new AmCharts.CategoryAxesSettings();
	categoryAxesSettings.minPeriod = "ss";
	chart.categoryAxesSettings = categoryAxesSettings;
	                                               
	// first stock panel
	var stockPanel1 = new AmCharts.StockPanel();
	stockPanel1.showCategoryAxis = false;
	stockPanel1.title = "Value";
	stockPanel1.percentHeight = 60;

	var graph1 = new AmCharts.StockGraph();
	graph1.valueField = "value";
	graph1.comparable = true;
	graph1.compareField = "value";
	stockPanel1.addStockGraph(graph1);
	stockPanel1.stockLegend = new AmCharts.StockLegend();

	// second stock panel
	var stockPanel2 = new AmCharts.StockPanel();
	stockPanel2.title = "Volume";
	stockPanel2.percentHeight = 40;
	
	var graph2 = new AmCharts.StockGraph();
	graph2.valueField = "value";
	graph2.type = "column";
	graph2.showBalloon = false;
	graph2.fillAlphas = 1;
	stockPanel2.addStockGraph(graph2);
	stockPanel2.stockLegend = new AmCharts.StockLegend();

	// set panels to the chart
	chart.panels = [stockPanel1, stockPanel2];

	// OTHER SETTINGS ////////////////////////////////////
	var sbsettings = new AmCharts.ChartScrollbarSettings();
	sbsettings.graph = graph1;
	sbsettings.usePeriod = "WW";
	chart.chartScrollbarSettings = sbsettings;

	// PERIOD SELECTOR ///////////////////////////////////
	var periodSelector = new AmCharts.PeriodSelector();
	periodSelector.position = "left";
	periodSelector.periods = [
		{period: "NN", count: 1, label: "1 phút", selected: true},
		{period: "NN", count: 10, label: "10 phút"},
		{period: "NN", count: 15, label: "15 phút"},
		{period: "NN", count: 30, label: "30 phút"},
		{period: "N", count: 45, label: "45 phút"},
		{period: "HH", count: 1, label: "1 giờ"},
		{period: "MAX", label: "Toàn bộ"}];
	chart.periodSelector = periodSelector;

	// DATA SET SELECTOR
	var dataSetSelector = new AmCharts.DataSetSelector();
	dataSetSelector.position = "left";
	chart.dataSetSelector = dataSetSelector;

	chart.addListener("rendered", function(event) {
		chart.mouseDown = false;
		chart.containerDiv.onmousedown = function() {
			chart.mouseDown = true;
		}
		chart.containerDiv.onmouseup = function() {
			chart.mouseDown = false;
		}
	});

	chart.write('chartdiv');
	setInterval(updateData, updateInterval);
}

$(function() {
    loadInfoData();
});