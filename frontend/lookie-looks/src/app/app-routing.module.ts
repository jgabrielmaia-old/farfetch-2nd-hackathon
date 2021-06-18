import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ChallengeComponent } from './pages/challenge/challenge.component';
import { SelectAttributeComponent } from './pages/select-attribute/select-attribute.component';

const routes: Routes = [
  { path: '', redirectTo: '/challenge', pathMatch: 'full' },
  { path: 'challenge', component: ChallengeComponent},
  { path: 'attributes', component: SelectAttributeComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
