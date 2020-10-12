import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-cards-ac',
  templateUrl: './cards-ac.component.html',
  styleUrls: ['./cards-ac.component.css']
})
export class CardsACComponent implements OnInit {

  @Input() CardStyle: string;
  @Input() Title: string;
  @Input() SubTitle: string;
  @Input() Description: string;

  constructor() { }

  ngOnInit(): void {
  }

}
