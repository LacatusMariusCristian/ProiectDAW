import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AddComponent } from './add/add.component';
import { EditComponent } from './edit/edit.component';


const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'add', component: AddComponent },
  { path: 'edit', component: EditComponent },
  { path: '**', component: HomeComponent },


];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
