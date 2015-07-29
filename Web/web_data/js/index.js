var infoPath = "realtime/data-power.json";
var dataLength = 600;
var updateInterval = 1000;

function generateChartData() {
	var length = 5;
	$.ajax({
		dataType: "json",
		url: infoPath,
		async: false,
		success: function(data) {
			length = data.length;
		}
	});
	
	var chartsData = [];
	
	var firstDate = Date.now() - (dataLength * updateInterval);
	for (var count = 0; count < length; count++) {
		chartData = [];
		for (var i = 0; i < dataLength; i++) {
			var newDate = new Date(firstDate + (i * updateInterval));
			var a = Math.random() * 100 + i * 2;
			chartData.push({
				date: newDate,
				value: a
			});
		}
		chartsData.push(chartData);
	}
	
	return chartsData;
}

function updateData() {
	var now = Date.now();
	$.ajax({
		dataType: "json",
		url: infoPath,
		async: true,
		success: function(data) {
			now = (now + Date.now()) / 2;
			
			var arrPower = [];
			$.each(data, function(key, value) {
				value = (value == -1 ? 0 : value);
				arrPower.push(value);
			});
			
			for (var i = 0; i < chartsData.length; i++) {
				var chartData = chartsData[i];
				chartData.shift();
				chartData.push({
					date: new Date(now),
					value: arrPower[i]
				});
			}
			
			if(!chart.mouseDown) {
				chart.validateData();
				var diffTime = now - chart.endDate.getTime();
				var newStartDate = new Date(chart.startDate.getTime() + diffTime);
				var newEndDate = new Date(chart.endDate.getTime() + diffTime);
				chart.zoom(newStartDate, newEndDate);
			}
		}
	});
}

function generateDataSets() {
	var dataSets = [];
	for (var i = 0; i < chartsData.length; i++) {
		var strTitle = (i == 0 ? "Tổng" : "Cảm biến " + i);
		dataSets.push({
			title: strTitle,
			fieldMappings: [{
				fromField: "value", toField: "value"
			}],
			dataProvider: chartsData[i],
			categoryField: "date"
		});
	}
	return dataSets;
}

var chartsData = generateChartData();
var chartDataSets = generateDataSets();
var chart = AmCharts.makeChart("chartdiv", {
	type: "stock",
	categoryAxesSettings: {
		minPeriod: "ss",
		groupToPeriods: ["ss", "5ss", "10ss", "30ss", "mm", "10mm", "30mm", "hh"]
	},
	dataSets: chartDataSets,
	mainDataSet: chartDataSets[0],
	panels: [{
			showCategoryAxis: false,
			mouseWheelZoomEnabled: true,
			title: "Biểu đồ lượng điện năng tiêu thụ",
			percentHeight: 70,
			valueAxes:[{
					id:"v1"
				}
			],
			stockGraphs: [{
				id: "g1",
				valueField: "value",
				type: "smoothedLine",
				lineThickness: 2,
				bullet: "round",
				comparable: true,
				compareField: "value",
				numberFormatter: {
					precision: 2,
					decimalSeparator: ".",
					thousandsSeparator: ","
				}
			}],
			stockLegend: {
				valueTextRegular: " ",
				markerType: "circle"
			}
		}, {
			title: "Biểu đồ cột lượng điện năng tiêu thụ",
			percentHeight: 30,
			stockGraphs: [{
				valueField: "value",
				type: "column",
				cornerRadiusTop: 2,
				fillAlphas: 1,
				numberFormatter: {
					precision: 4,
					decimalSeparator: ".",
					thousandsSeparator: ","
				}
			}],
			stockLegend: {
				valueTextRegular: " ",
				markerType: "circle"
			}
		}
	],
	chartScrollbarSettings: {
		graph: "g1",
		usePeriod: "5ss",
		position: "top"
	},
	chartCursorSettings: {
		valueBalloonsEnabled: true,
		valueLineBalloonEnabled: true,
		valueLineEnabled:true
	},
	periodSelector: {
		position: "left",
		dateFormat: "YYYY-MM-DD HH:NN:SS",
		inputFieldWidth: 150,
		periods: [{
			period: "ss",
			count: 15,
			label: "15 seconds"
		}, {
			period: "ss",
			count: 30,
			label: "30 seconds",
			selected: true
		}, {
			period: "ss",
			count: 45,
			label: "45 seconds"
		}, {
			period: "mm",
			count: 1,
			label: "1 minute"
		}, {
			period: "mm",
			count: 5,
			label: "5 minutes"
		}, {
			period: "mm",
			count: 10,
			label: "10 minutes"
		}, {
			period: "MAX",
			label: "MAX"
		}]
	},
	dataSetSelector: {
		position: "left"
	},
	listeners: [
		{
			event: "rendered",
			method: function(event) {
				chart.mouseDown = false;
				chart.containerDiv.onmousedown = function() {
					chart.mouseDown = true;
				};
				chart.containerDiv.onmouseup = function() {
					chart.mouseDown = false;
				};
			}
		}
	]
});
setInterval(updateData, updateInterval);