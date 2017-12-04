import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';

import { StoreModule } from '@ngrx/store';
import { simpleReducer } from './reducers/simple.reducer';
import { postReducer } from './reducers/post.reducer';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';

import { ProjectsModule } from './projects/projects.module';
import { HomeModule } from './home/home.module';
import { SharedModule } from './shared/shared.module';
import { Project } from './shared/models/project';

// material modules
import { NoopAnimationsModule } from '@angular/platform-browser/animations';
import { MatInputModule } from '@angular/material/input';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatMenuModule } from '@angular/material/menu';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
  declarations: [
    AppComponent,
  ],
  imports: [
    StoreModule.forRoot({
      message: simpleReducer,
      post: postReducer
    }),
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    ProjectsModule,
    HomeModule,
    SharedModule,

    NoopAnimationsModule,
    MatInputModule,
    MatToolbarModule,
    MatMenuModule,
    MatButtonModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
