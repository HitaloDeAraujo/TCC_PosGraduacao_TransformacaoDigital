import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

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
import { NormaService } from './services/norma.service'
import { UsuarioService } from './services/usuario.service'
import { RepositorioService } from './services/repositorio.service'
import { EventoService } from './services/evento.service'
import { RequestInterceptor } from './utils/request-interceptor'
import { HTTP_INTERCEPTORS, HttpClientModule } from "@angular/common/http";
import { AssessoriasConsultoriasPageComponent } from './pages/AssessoriasConsultorias/Home/assessorias-consultorias-page/assessorias-consultorias-page.component';
import { NavPrincipalComponent } from './controls/nav-principal/nav-principal.component';
import { CardsACComponent } from './pages/AssessoriasConsultorias/Home/CardsAC/cards-ac/cards-ac.component';
import { DataTablesModule } from 'angular-datatables';
import { ListagemParceirosComponent } from './pages/AssessoriasConsultorias/Parceiros/listagem-parceiros/listagem-parceiros.component';
import { GestaoNormasPageComponent } from './pages/GestaoNormas/Home/gestao-normas-page/gestao-normas-page.component';
import { ListagemNormasComponent } from './pages/GestaoNormas/Normas/listagem-normas/listagem-normas.component';
import { ListagemRepositoriosComponent } from './pages/GestaoNormas/Repositorios/listagem-repositorios/listagem-repositorios.component';
import { CardGestaoNormasHomeComponent } from './pages/GestaoNormas/Home/Cards/card-gestao-normas-home/card-gestao-normas-home.component';
import { InclusaoRepositorioComponent } from './pages/GestaoNormas/Repositorios/inclusao-repositorio/inclusao-repositorio.component';
import { NavigationGuardService } from './security/navigation.guard.service';
import { from } from 'rxjs';

@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,
    IconSIGOComponent,
    GestaoProcessoIndustrialPageComponent,
    OrcamentosPedidosMesesGraphComponent,
    OrcamentosPedidosMesGraphComponent,
    AssessoriasConsultoriasPageComponent,
    NavPrincipalComponent,
    CardsACComponent,
    ListagemParceirosComponent,
    GestaoNormasPageComponent,
    ListagemNormasComponent,
    ListagemRepositoriosComponent,
    CardGestaoNormasHomeComponent,
    InclusaoRepositorioComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    ChartsModule,
    BrowserAnimationsModule,
    HttpClientModule,
    DataTablesModule,
    FormsModule,
    ReactiveFormsModule,
    ToastrModule.forRoot()
  ],
  providers: [
    BaseService,
    ParceiroService,
    NormaService,
    RepositorioService,
    UsuarioService,
    EventoService,
    [NavigationGuardService],
    { provide: HTTP_INTERCEPTORS, useClass: RequestInterceptor, multi: true }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
