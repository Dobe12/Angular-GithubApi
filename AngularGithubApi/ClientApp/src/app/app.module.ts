import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { WebApiServiceService} from './github/services/web-api-service.service';
import {HttpClient, HttpClientModule} from '@angular/common/http';
import { CommonModule} from '@angular/common';


import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GithubComponent } from './github/github.component';

@NgModule({
  declarations: [
    AppComponent,
    GithubComponent,
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    HttpClientModule
  ],
  providers: [WebApiServiceService],
  bootstrap: [AppComponent]
})
export class AppModule { }
