import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-icon-sigo',
  templateUrl: './icon-sigo.component.html',
  styleUrls: ['./icon-sigo.component.css']
})

export class IconSIGOComponent implements OnInit {

  @Input() Title: string;
  @Input() ClassIcon: string;
  
  constructor() { }

  ngOnInit(): void {
  }

}
