import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { AppRoutingModule } from './app-routing.module';
import { IconSIGOComponent } from './controls/icon-sigo/icon-sigo.component';
import { GestaoProcessoIndustrialPageComponent } from './pages/GestaoProcessoIndustrial/gestao-processo-industrial-page/gestao-processo-industrial-page.component';

import { ChartsModule } from 'ng2-charts';
import { OrcamentosPedidosMesesGraphComponent } from './pages/GestaoProcessoIndustrial/gestao-processo-industrial-page/Graphs/orcamentos-pedidos-meses-graph/orcamentos-pedidos-meses-graph.component';
import { OrcamentosPedidosMesGraphComponent } from './pages/GestaoProcessoIndustrial/gestao-processo-industrial-page/Graphs/orcamentos-pedidos-mes-graph/orcamentos-pedidos-mes-graph.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,
    IconSIGOComponent,
    GestaoProcessoIndustrialPageComponent,
    OrcamentosPedidosMesesGraphComponent,
    OrcamentosPedidosMesGraphComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ChartsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
