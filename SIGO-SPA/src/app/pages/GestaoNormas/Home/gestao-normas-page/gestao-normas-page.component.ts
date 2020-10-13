import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { NormaService } from '../../../../services/norma.service';
import { RepositorioService } from '../../../../services/repositorio.service';

@Component({
  selector: 'app-gestao-normas-page',
  templateUrl: './gestao-normas-page.component.html',
  styleUrls: ['./gestao-normas-page.component.css']
})
export class GestaoNormasPageComponent implements OnInit {

  public quantNormas;
  public quantRepositorios;

  constructor(private normaService: NormaService, private repositorioService: RepositorioService, private router: Router, private route: ActivatedRoute, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.obterNormas();
    this.obterRepositorios();
  }

  public onMenuClick(modulo) {
    this.router.navigate([modulo]);
  }

  obterNormas() {
    this.normaService.Get().subscribe(

      result => {

        if (result != null) {
          this.quantNormas = result["length"];;
        }
        else
          this.toastr.error("Erro", "Alerta");
      },
      error => {
        this.toastr.error("Erro", "Alerta");
      }
    );
  }

  obterRepositorios() {
    this.repositorioService.Get().subscribe(

      result => {

        if (result != null) {
          this.quantRepositorios = result["length"];
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
