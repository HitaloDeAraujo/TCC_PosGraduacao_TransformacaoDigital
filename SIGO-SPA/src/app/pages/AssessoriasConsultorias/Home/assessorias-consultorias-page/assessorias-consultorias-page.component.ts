import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { ParceiroService } from '../../../../services/parceiro.service'

@Component({
  selector: 'app-assessorias-consultorias-page',
  templateUrl: './assessorias-consultorias-page.component.html',
  styleUrls: ['./assessorias-consultorias-page.component.css']
})
export class AssessoriasConsultoriasPageComponent implements OnInit {

  constructor(private parceiroService: ParceiroService, private router: Router, private route: ActivatedRoute, private toastr: ToastrService) { }
  
  ngOnInit(): void {
  }

  public onMenuClick(menu) {
    this.router.navigate([menu]);
  }
}