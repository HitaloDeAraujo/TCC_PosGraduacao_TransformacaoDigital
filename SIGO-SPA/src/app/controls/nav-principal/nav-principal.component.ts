import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-nav-principal',
  templateUrl: './nav-principal.component.html',
  styleUrls: ['./nav-principal.component.css']
})
export class NavPrincipalComponent implements OnInit {

  constructor(private router: Router, private route: ActivatedRoute, private toastr: ToastrService) { }

  ngOnInit(): void {
  }

  public onSair(){
    this.router.navigate(['']);
    this.toastr.success('Sessão encerrada!');
  }

}
