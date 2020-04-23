var mydata = [
['ug', 0],
['ng', 1],
['st', 2],
['tz', 3],
['sl', 4],
['gw', 5],
['cv', 6],
['sc', 7],
['tn', 8],
['mg', 9],
['ke', 10],
['cd', 11],
['fr', 12],
['mr', 13],
['dz', 14],
['er', 15],
['gq', 16],
['mu', 17],
['sn', 18],
['km', 19],
['et', 20],
['ci', 21],
['gh', 22],
['zm', 23],
['na', 24],
['rw', 25],
['sx', 26],
['so', 27],
['cm', 28],
['cg', 29],
['eh', 30],
['bj', 31],
['bf', 32],
['tg', 33],
['ne', 34],
['ly', 35],
['lr', 36],
['mw', 37],
['gm', 38],
['td', 39],
['ga', 40],
['dj', 41],
['bi', 42],
['ao', 43],
['gn', 44],
['zw', 45],
['za', 46],
['mz', 47],
['sz', 48],
['ml', 49],
['bw', 50],

];
// Initiate the chart
Highcharts.mapChart('container', {

    legend: {
        enabled: false
    },
    exporting: { enabled: false },
    credits: {
        enabled: false
    },
    plotOptions: {
        series: {
            events: {
                click: function (e) {
                    var text = '<b>Clicked</b><br> ' + e.point.name;
                    if (!this.chart.clickLabel) {
                        this.chart.clickLabel = this.chart.renderer.label(text, 0, 250)
                            .css({
                                width: '180px'
                            })
                            .add();
                    } else {
                        this.chart.clickLabel.attr({
                            text: text
                        });
                    }
                }
            }
        }
    },

    series: [{
        nullColor: '#000000',
        data: mydata,
        mapData: Highcharts.maps['custom/africa'],
        name: '',
        states: {
            hover: {
                color: '#FFFFFF'
            }
        }
    }]
});
