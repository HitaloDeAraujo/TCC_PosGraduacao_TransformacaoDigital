import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';
import { NormaService } from '../../../../services/norma.service';
import { DataTablesOptions } from '../../../../utils/data-tables-utils';

@Component({
  selector: 'app-listagem-normas',
  templateUrl: './listagem-normas.component.html',
  styleUrls: ['./listagem-normas.component.css']
})
export class ListagemNormasComponent implements OnInit {

  public normas;

  dtOptions: any;

  public dtTrigger: Subject<any> = new Subject<any>();

  constructor(private normaService: NormaService, private router: Router, private route: ActivatedRoute, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.dtOptions = DataTablesOptions.PortuguesBrasil;

    this.obterNormas();
  }

  public onMenuClick(modulo) {
    this.router.navigate([modulo]);
  }

  obterNormas() {
    this.normaService.Get().subscribe(

      result => {

        if (result != null) {
          this.normas = result;
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
}
