import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ComoQuierasLLamale } from './Contador/contador.component';
import { HeroComponent } from './heroes/hero/hero.component';
import { SharedModule } from './shared/shared.module';
import { LineChartComponent } from './app/line-chart/line-chart.component';








@NgModule({
  declarations: [
    AppComponent,
    ComoQuierasLLamale,
    HeroComponent,
    LineChartComponent,
    ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,

    AppRoutingModule,
    SharedModule,
    // PageNotFoundComponent
    // MapsModule

  ],
  providers: [],
  bootstrap: [AppComponent,]
})
export class AppModule {




 }
