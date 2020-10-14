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

  dtOptions: any;

  public dtTrigger: Subject<any> = new Subject<any>();

  constructor(private eventoService: EventoService, private router: Router, private route: ActivatedRoute, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.dtOptions = DataTablesOptions.PortuguesBrasil;
    this.obterEventos();
  }

  public onMenuClick(modulo) {
    this.router.navigate([modulo]);
  }

  obterEventos() {
    this.eventoService.Get().subscribe(

      result => {

        if (result != null) {

          debugger;
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

  startTimer() {
    setInterval(() => {
      this.toastr.success('Sessão encerrada!');
    }, 1000)
  }
}
