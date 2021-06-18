import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ChallengeComponent } from './pages/challenge/challenge.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { SelectAttributeComponent } from './pages/select-attribute/select-attribute.component';
import { CurrentGamesComponent } from './pages/current-games/current-games.component';

@NgModule({
  declarations: [
    AppComponent,
    ChallengeComponent,
    SelectAttributeComponent,
    CurrentGamesComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    NgbModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
