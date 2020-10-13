import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Subject } from 'rxjs';
import { ParceiroService } from '../../../../services/parceiro.service';
import { DataTablesOptions } from '../../../../utils/data-tables-utils';

@Component({
  selector: 'app-listagem-parceiros',
  templateUrl: './listagem-parceiros.component.html',
  styleUrls: ['./listagem-parceiros.component.css']
})

export class ListagemParceirosComponent implements OnInit {

  dtOptions: any;

  public dtTrigger: Subject<any> = new Subject<any>();

  public parceiros;

  constructor(private parceiroService: ParceiroService, private router: Router, private route: ActivatedRoute, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.dtOptions = DataTablesOptions.PortuguesBrasil;

    this.obterParceiros();
  }

  public onMenuClick(menu) {
    this.router.navigate([menu]);
  }

  obterParceiros() {
    this.parceiroService.Get().subscribe(

      result => {

        if (result != null) {
          debugger;
          this.parceiros = result;
          this.toastr.success('Sucesso');
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
