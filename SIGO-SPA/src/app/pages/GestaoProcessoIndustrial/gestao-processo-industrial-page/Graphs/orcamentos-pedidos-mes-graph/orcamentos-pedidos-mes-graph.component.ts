import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-orcamentos-pedidos-mes-graph',
  templateUrl: './orcamentos-pedidos-mes-graph.component.html',
  styleUrls: ['./orcamentos-pedidos-mes-graph.component.css']
})
export class OrcamentosPedidosMesGraphComponent implements OnInit {

  public barChartOptions = {
    scaleShowVerticalLines: false,
    responsive: true
  };

  public barChartLabels = ['Orçamentos', 'Pedidos'];

  public barChartType = 'pie';
  public barChartLegend = true;
  public barChartData = [{data: [60,40]}];

  constructor() { }

  ngOnInit(): void {
  }

}
