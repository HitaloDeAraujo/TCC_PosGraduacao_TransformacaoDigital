import { RouterModule, Routes } from "@angular/router";
import { LoginPageComponent } from "./pages/login-page/login-page.component";
import { GestaoProcessoIndustrialPageComponent } from "./pages/GestaoProcessoIndustrial/gestao-processo-industrial-page/gestao-processo-industrial-page.component";
import { AssessoriasConsultoriasPageComponent } from "./pages/AssessoriasConsultorias/Home/assessorias-consultorias-page/assessorias-consultorias-page.component";
import { ListagemParceirosComponent } from "./pages/AssessoriasConsultorias/Parceiros/listagem-parceiros/listagem-parceiros.component"
import { GestaoNormasPageComponent } from "./pages/GestaoNormas/Home/gestao-normas-page/gestao-normas-page.component"
import { ListagemNormasComponent } from "./pages/GestaoNormas/Normas/listagem-normas/listagem-normas.component"
import { ListagemRepositoriosComponent } from "./pages/GestaoNormas/Repositorios/listagem-repositorios/listagem-repositorios.component";
import { InclusaoRepositorioComponent } from "./pages/GestaoNormas/Repositorios/inclusao-repositorio/inclusao-repositorio.component"
1
import { NgModule } from "@angular/core";
import { NavigationGuardService } from "./security/navigation.guard.service";

const appRoutes: Routes = [
  {
    path: "",
    component: LoginPageComponent
  },
  {
    path: "GestaoProcessoIndustrial",
    component: GestaoProcessoIndustrialPageComponent,
    canActivate: [NavigationGuardService]
  },
  {
    path: "AssessoriasConsultorias",
    component: AssessoriasConsultoriasPageComponent,
    canActivate: [NavigationGuardService]
  },
  {
    path: "AssessoriasConsultorias/Parceiros",
    component: ListagemParceirosComponent,
    canActivate: [NavigationGuardService]
  },
  {
    path: "GestaoNormas",
    component: GestaoNormasPageComponent,
    canActivate: [NavigationGuardService]
  },
  {
    path: "GestaoNormas/Normas",
    component: ListagemNormasComponent,
    canActivate: [NavigationGuardService]
  },
  {
    path: "GestaoNormas/Repositorios",
    component: ListagemRepositoriosComponent,
    canActivate: [NavigationGuardService]
  },
  {
    path: "GestaoNormas/Repositorios/Novo",
    component: InclusaoRepositorioComponent,
    canActivate: [NavigationGuardService]
  }
];

@NgModule({
  imports: [
    RouterModule.forRoot(
      appRoutes,
      { enableTracing: false }
    )
  ],
  exports: [
    RouterModule
  ]
})
export class AppRoutingModule { }