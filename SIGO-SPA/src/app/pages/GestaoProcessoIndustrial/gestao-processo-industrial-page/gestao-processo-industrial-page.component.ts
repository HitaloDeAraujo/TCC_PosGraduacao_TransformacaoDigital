import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ParceiroService } from '../../../services/parceiro.service';

@Component({
  selector: 'app-gestao-processo-industrial-page',
  templateUrl: './gestao-processo-industrial-page.component.html',
  styleUrls: ['./gestao-processo-industrial-page.component.css']
})

export class GestaoProcessoIndustrialPageComponent implements OnInit {
  
  constructor(private parceiroService: ParceiroService, private router: Router, private route: ActivatedRoute, private toastr: ToastrService) { }
  

  ngOnInit(): void {
    //this.startTimer();
    this.obterParceiros();
  }

  obterParceiros() {
    this.parceiroService.Get().subscribe(

      result => {

        if (result != null) {

          this.toastr.success('Sucesso');
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
    },1000)


  }
  public onSair(){
    this.router.navigate(['']);
    this.toastr.success('Sessão encerrada!');
  }
}
