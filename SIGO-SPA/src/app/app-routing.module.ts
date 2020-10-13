import { RouterModule, Routes } from "@angular/router";
import { LoginPageComponent } from "./pages/login-page/login-page.component";
import { GestaoProcessoIndustrialPageComponent } from "./pages/GestaoProcessoIndustrial/gestao-processo-industrial-page/gestao-processo-industrial-page.component";
import { AssessoriasConsultoriasPageComponent } from "./pages/AssessoriasConsultorias/Home/assessorias-consultorias-page/assessorias-consultorias-page.component";
import { ListagemParceirosComponent } from "./pages/AssessoriasConsultorias/Parceiros/listagem-parceiros/listagem-parceiros.component"
import { NgModule } from "@angular/core";

const appRoutes: Routes = [
  {
    path: "",
    component: LoginPageComponent
  },
  {
    path: "GestaoProcessoIndustrial",
    component: GestaoProcessoIndustrialPageComponent
  },
  {
    path: "AssessoriasConsultorias",
    component: AssessoriasConsultoriasPageComponent
  },
  {
    path: "AssessoriasConsultorias/Parceiros",
    component: ListagemParceirosComponent
  }
];

@NgModule({
    imports: [
      RouterModule.forRoot(
        appRoutes,
        { enableTracing: true } // <-- debugging purposes only
      )
    ],
    exports: [
      RouterModule
    ]
  })
  export class AppRoutingModule {}
 