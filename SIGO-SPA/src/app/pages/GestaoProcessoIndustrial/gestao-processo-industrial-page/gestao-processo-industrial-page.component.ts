import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { DataTablesOptions } from '../../../utils/data-tables-utils';

@Component({
  selector: 'app-gestao-processo-industrial-page',
  templateUrl: './gestao-processo-industrial-page.component.html',
  styleUrls: ['./gestao-processo-industrial-page.component.css']
})

export class GestaoProcessoIndustrialPageComponent implements OnInit {

  constructor(private router: Router, private route: ActivatedRoute, private toastr: ToastrService) { }

  dtOptions: any;

  ngOnInit(): void {
    this.dtOptions = DataTablesOptions.PortuguesBrasil;
  }

  public onMenuClick(modulo) {
    this.router.navigate([modulo]);
  }

  startTimer() {
    setInterval(() => {
      this.toastr.success('Sessão encerrada!');
    }, 1000)
  }
}
