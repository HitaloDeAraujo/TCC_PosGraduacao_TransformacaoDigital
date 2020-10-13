import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, AbstractControl  } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { RepositorioDTO } from '../../../../DTOs/repositorio.dto';
import { RepositorioService } from '../../../../services/repositorio.service';

@Component({
  selector: 'app-inclusao-repositorio',
  templateUrl: './inclusao-repositorio.component.html',
  styleUrls: ['./inclusao-repositorio.component.css']
})
export class InclusaoRepositorioComponent implements OnInit {

  public repositorioForm;

  constructor(private repositorioService: RepositorioService, private router: Router, private route: ActivatedRoute, private toastr: ToastrService) { }

  ngOnInit(): void {
    this.repositorioForm = new FormGroup({
      url: new FormControl('', [Validators.required, this.urlValidator]),
      nome: new FormControl('', [Validators.required, this.nomeValidator]),
      descricao: new FormControl('', [Validators.required, this.descricaoValidator])
    });
  }

  public onMenuClick(menu) {
    this.router.navigate([menu]);
  }

  private urlValidator(control: AbstractControl){
    let result = null;

    if(control.dirty) {
      if(control.value == null){
        result = { TextError: "Não pode estar vazio" };
      }
    }

    return result;
  }

  private nomeValidator(control: AbstractControl){
    let result = null;

    if(control.dirty) {
      if(control.value == null){
        result = { TextError: "Não pode estar vazio" };
      }
    }

    return result;
  }

  private descricaoValidator(control: AbstractControl){
    let result = null;

    if(control.dirty) {
      if(control.value == null){
        result = { TextError: "Não pode estar vazio" };
      }
    }

    return result;
  }

  public onSubmit(){

    let repositorioDTO = new RepositorioDTO();

    repositorioDTO.Nome = this.repositorioForm.value.nome;
    repositorioDTO.URL = this.repositorioForm.value.url;
    repositorioDTO.Descricao = this.repositorioForm.value.descricao;

    this.repositorioService.Post(repositorioDTO).subscribe(

      result => {

        if (result != null) {
          this.toastr.error("Repositório cadastrado com sucesso", "Alerta");
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