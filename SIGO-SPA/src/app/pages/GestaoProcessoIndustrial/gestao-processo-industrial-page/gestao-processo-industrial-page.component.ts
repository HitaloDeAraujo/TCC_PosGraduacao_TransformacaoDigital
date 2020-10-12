import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-gestao-processo-industrial-page',
  templateUrl: './gestao-processo-industrial-page.component.html',
  styleUrls: ['./gestao-processo-industrial-page.component.css']
})
export class GestaoProcessoIndustrialPageComponent implements OnInit {

  public barChartOptions = {
    scaleShowVerticalLines: false,
    responsive: true
  };
  public barChartLabels = [ 'novembro', 'dezembro', 'janeiro', 'fevereiro', 'março', 'abril', 'maio', 'junho', 'julho', 'agosto',
   'setembro', 'outubro'];

  public barChartType = 'bar';
  public barChartLegend = true;
  public barChartData1 = [
    {data: [6511, 5648, 5486, 4533, 6132, 7445, 7431, 8431, 5012, 7464, 8313, 9015], label: 'Orçamentos'},
    {data: [3501, 3608, 3489, 2583, 4102, 4945, 6531, 5314, 4232, 7300, 6001, 8115], label: 'Vendas'}
  ];
  
  constructor() { }

  ngOnInit(): void {
  }

}
