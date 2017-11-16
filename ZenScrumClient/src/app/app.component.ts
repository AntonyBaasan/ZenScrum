import { Component, Input } from '@angular/core';

import { Store } from '@ngrx/store';
import { Observable } from 'rxjs/Observable';
import { Post } from './reducers/post.model';
import * as PostActions from './reducers/post.actions';

interface AppState {
  message: string;
  post: Post;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'app';
  message$: Observable<string>;
  post$: Observable<Post>;

  @Input()
  text: string; // form input val

  constructor(private store: Store<AppState>) {
    this.message$ = this.store.select('message');
    this.post$ = this.store.select('post');
  }

  switchToSpanish() {
    this.store.dispatch({ type: 'SPANISH' });
  }
  switchToFrench() {
    this.store.dispatch({ type: 'FRENCH' });
  }

  editText() {
    this.store.dispatch(new PostActions.EditText(this.text));
  }
  resetPost() {
    this.store.dispatch(new PostActions.Reset());
  }
  upVote() {
    this.store.dispatch(new PostActions.UpVote());
  }
  downVote() {
    this.store.dispatch(new PostActions.DownVote());
  }
}
