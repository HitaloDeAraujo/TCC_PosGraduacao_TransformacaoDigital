import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppComponent } from './app.component';
import { LoginPageComponent } from './pages/login-page/login-page.component';
import { AppRoutingModule } from './app-routing.module';
import { IconSIGOComponent } from './controls/icon-sigo/icon-sigo.component';
import { GestaoProcessoIndustrialPageComponent } from './pages/GestaoProcessoIndustrial/gestao-processo-industrial-page/gestao-processo-industrial-page.component';

@NgModule({
  declarations: [
    AppComponent,
    LoginPageComponent,
    IconSIGOComponent,
    GestaoProcessoIndustrialPageComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
