import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';

@Component({
  selector: 'app-card-gestao-normas-home',
  templateUrl: './card-gestao-normas-home.component.html',
  styleUrls: ['./card-gestao-normas-home.component.css']
})
export class CardGestaoNormasHomeComponent implements OnInit {

  @Input() Title: string;
  @Input() Descricao: string;
  @Input() ActionText: string;
  @Input() Image: string;
  @Input() Value: string;

  @Output() ActionClicked = new EventEmitter();

  constructor() { }

  ngOnInit(): void {
  }

  public onActionClick() {
    this.ActionClicked.emit(this.Value);
  }
}
