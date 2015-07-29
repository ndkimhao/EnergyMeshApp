var infoPath = "realtime/data.json";
var maxDataLength = 500;
var updateInterval = 1000;

var dataSets = [];
var chart;

function generateChartData() {
    var firstDate = new Date();
    firstDate.setSeconds(firstDate.getSeconds() - (maxDataLength * updateInterval/1000));
	for (var c = 0; c < 5; c++) {
		var arr = [];
		for (var i = 0; i < 500; i++) {
			var newDate = new Date(firstDate);
			newDate.setDate(newDate.getDate() + i);
			var a1 = Math.round(Math.random() * (40 + i)) + 100 + i;
			arr.push({
				date: newDate,
				value: a1
			});
		}
		dataSets.push(arr);
	}
}

AmCharts.ready(function() {
    generateChartData();
    createStockChart();
});

function createStockChart() {
    chart = new AmCharts.AmStockChart();
    //chart.glueToTheEnd = true;

    // DATASETS //////////////////////////////////////////
    // create data sets first
	var arr_ds = [];
	$.each(dataSets, function(key, val){
		var dataSet = new AmCharts.DataSet();
		dataSet.title = "first data set";
		dataSet.fieldMappings = [{fromField: "value", toField: "value"}];
		dataSet.dataProvider = val;
		dataSet.categoryField = "date";
		arr_ds.push(dataSet);
	});

    // set data sets to the chart
    chart.dataSets = arr_ds;
    chart.mainDataSet = arr_ds[0];
	
	var categoryAxesSettings = new AmCharts.CategoryAxesSettings();
	categoryAxesSettings.minPeriod = "NN";
	chart.categoryAxesSettings = categoryAxesSettings;

    // PANELS ///////////////////////////////////////////                                                  
    // first stock panel
    var stockPanel1 = new AmCharts.StockPanel();
    stockPanel1.showCategoryAxis = false;
    stockPanel1.title = "Value";
    stockPanel1.percentHeight = 60;

    // graph of first stock panel
    var graph1 = new AmCharts.StockGraph();
    graph1.valueField = "value";
    graph1.comparable = true;
    graph1.compareField = "value";
    stockPanel1.addStockGraph(graph1);

    // create stock legend                
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
    periodSelector.periods = [{
        period: "mm",
        selected: true,
        count: 1,
        label: "1 phút"},
	{
        period: "DD",
        count: 10,
        label: "10 days"},
    {
        period: "MM",
        count: 1,
        label: "1 month"},
    {
        period: "YYYY",
        count: 1,
        label: "1 year"},
    {
        period: "YTD",
        label: "YTD"},
    {
        period: "MAX",
        label: "MAX"}];
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
    
    // set up the chart to update every second
    setInterval(function () {
        
        // if mouse is down, stop all updates
        if ( chart.mouseDown )
            return;
        
        // normally you would load new datapoints here,
        // but we will just generate some random values
        // and remove the value from the beginning so that
        // we get nice sliding graph feeling
        
        // remove datapoint from the beginning
		for (var c = 0; c < 5; c++) {
			dataSets[c].shift();
			
			// add new datapoint at the end
			var newDate = new Date(dataSets[c][dataSets[c].length - 1].date);
			newDate.setSeconds(newDate.getSeconds() + 1);

			var a1 = Math.round(Math.random() * (40 + c)) + 100 + c;

			chart.dataSets[c].dataProvider.push({
				date: newDate,
				value: a1
			});
			
			chart.validateData();
			
			// adjust zoom
			
			var newStartDate = new Date(chart.startDate.getTime());
			newStartDate.setSeconds(newStartDate.getSeconds() + 1);
			var newEndDate = new Date(chart.endDate.getTime());
			newEndDate.setSeconds(newEndDate.getSeconds() + 1);
			chart.zoom(newStartDate, newEndDate);
		}
    }, 1000);
}