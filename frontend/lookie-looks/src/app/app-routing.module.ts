import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChallengeComponent } from './pages/challenge/challenge.component';

const routes: Routes = [
  { path: '', redirectTo: '/challenge', pathMatch: 'full' },
   { path: 'challenge', component: ChallengeComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
