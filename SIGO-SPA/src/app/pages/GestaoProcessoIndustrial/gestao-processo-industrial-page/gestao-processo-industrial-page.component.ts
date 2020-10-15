import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { EventoService } from '../../../services/evento.service';
import { DataTablesOptions } from '../../../utils/data-tables-utils';
import { Subject } from 'rxjs';

@Component({
  selector: 'app-gestao-processo-industrial-page',
  templateUrl: './gestao-processo-industrial-page.component.html',
  styleUrls: ['./gestao-processo-industrial-page.component.css']
})

export class GestaoProcessoIndustrialPageComponent implements OnInit {

  public eventos;
  public relacaoOrcamentosVendas;

  dtOptions: any;

  public dtTrigger: Subject<any> = new Subject<any>();

  constructor(private eventoService: EventoService, private router: Router, private route: ActivatedRoute, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.dtOptions = DataTablesOptions.PortuguesBrasil;
    this.obterEventos();
    this.startTimerObterRelacaoOrcamentosVendas();

    this.relacaoOrcamentosVendas = [{ data: [50, 50] }];
  }

  public onMenuClick(modulo) {
    this.router.navigate([modulo]);
  }

  obterEventos() {
    this.eventoService.Get().subscribe(

      result => {

        if (result != null) {
          this.eventos = result;
          this.dtTrigger.next();
        }
        else
          this.toastr.error("Erro", "Alerta");
      },
      error => {
        this.toastr.error("Erro", "Alerta");
      }
    );
  }

  obterRelacaoOrcamentosVendas() {
    this.eventoService.ObterRelacaoOrcamentosVendas().subscribe(

      result => {

        if (result != null) {
          let relacaoOrcamentosVendas: RelacaoOrcamentosVendas = JSON.parse(result["descricao"]);

          if (relacaoOrcamentosVendas.Orcamentos != this.relacaoOrcamentosVendas[0].data[0]) {
            this.relacaoOrcamentosVendas = [{ data: [relacaoOrcamentosVendas.Orcamentos, relacaoOrcamentosVendas.Vendas] }];
          }
        }
        else
          this.toastr.error("Erro", "Alerta");
      },
      error => {
        this.toastr.error("Erro", "Alerta");
      }
    );
  }

  startTimerObterRelacaoOrcamentosVendas() {
    setInterval(() => {
      this.obterRelacaoOrcamentosVendas();
    }, 10000)
  }
}

interface RelacaoOrcamentosVendas {
  Orcamentos: string;
  Vendas: string;
}