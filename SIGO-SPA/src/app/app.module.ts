import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { AppComponent } from './app.component';
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { AppRoutingModule } from './app-routing.module';
import { IconSIGOComponent } from './controls/icon-sigo/icon-sigo.component';
import { GestaoProcessoIndustrialPageComponent } from './pages/GestaoProcessoIndustrial/gestao-processo-industrial-page/gestao-processo-industrial-page.component';

import { ChartsModule } from 'ng2-charts';
import { OrcamentosPedidosMesesGraphComponent } from './pages/GestaoProcessoIndustrial/gestao-processo-industrial-page/Graphs/orcamentos-pedidos-meses-graph/orcamentos-pedidos-meses-graph.component';
import { OrcamentosPedidosMesGraphComponent } from './pages/GestaoProcessoIndustrial/gestao-processo-industrial-page/Graphs/orcamentos-pedidos-mes-graph/orcamentos-pedidos-mes-graph.component';
import { ToastrModule } from 'ngx-toastr';
import { BaseService } from './services/base.service'
import { ParceiroService } from './services/parceiro.service'
import { RequestInterceptor } from './utils/request-interceptor'
import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";
import { AssessoriasConsultoriasPageComponent } from './pages/AssessoriasConsultorias/Home/assessorias-consultorias-page/assessorias-consultorias-page.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,
    IconSIGOComponent,
    GestaoProcessoIndustrialPageComponent,
    OrcamentosPedidosMesesGraphComponent,
    OrcamentosPedidosMesGraphComponent,
    AssessoriasConsultoriasPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ChartsModule,
    BrowserAnimationsModule,
    HttpClientModule,
    ToastrModule.forRoot()
  ],
  providers: [
    BaseService,
    ParceiroService,
    { provide: HTTP_INTERCEPTORS, useClass: RequestInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
