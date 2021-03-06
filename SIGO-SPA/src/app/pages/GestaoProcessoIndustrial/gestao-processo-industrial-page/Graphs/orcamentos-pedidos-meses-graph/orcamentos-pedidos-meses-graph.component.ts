import { Component, Input, OnInit, SimpleChanges } from '@angular/core';

@Component({
  selector: 'app-orcamentos-pedidos-meses-graph',
  templateUrl: './orcamentos-pedidos-meses-graph.component.html',
  styleUrls: ['./orcamentos-pedidos-meses-graph.component.css']
})
export class OrcamentosPedidosMesesGraphComponent implements OnInit {

  public barChartOptions = {
    scaleShowVerticalLines: false,
    responsive: true
  };

  public barChartLabels = ['novembro', 'dezembro', 'janeiro', 'fevereiro', 'março', 'abril', 'maio', 'junho', 'julho', 'agosto',
    'setembro', 'outubro'];

  public barChartType = 'bar';
  public barChartLegend = true;
  public BarChartData = [
    { data: [6511, 5648, 5486, 4533, 6132, 7445, 7431, 8431, 5012, 7464, 8313, 9015], label: 'Orçamentos' },
    { data: [3501, 3608, 3489, 2583, 4102, 4945, 6531, 5314, 4232, 7300, 6001, 8115], label: 'Vendas' }
  ];

  @Input() BarChartDataBind = [];
  @Input() Title: string;
  
  constructor() { }

  ngOnInit(): void {
  }

  ngOnChanges(Changes: SimpleChanges) {

    if (Changes.BarChartDataBind != undefined && Changes.BarChartDataBind.currentValue != undefined){
      
      debugger;
      this.BarChartData = [
        { data: [6511, 5648, 5486, 4533, 6132, 7445, 7431, 8431, 5012, 7464, 8313, Changes.BarChartDataBind.currentValue[0].data[0]], label: 'Orçamentos' },
        { data: [3501, 3608, 3489, 2583, 4102, 4945, 6531, 5314, 4232, 7300, 6001, Changes.BarChartDataBind.currentValue[0].data[1]], label: 'Vendas' }
      ];
    }
  }

}
