import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
interface NewsStories  {
  id: number;
  title: string;
  poll: number;
  score: number;
  url: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  public newsstories: NewsStories[] = [];
  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getStories();
  }

  getStories() {
    this.http.get<NewsStories[]>('/weatherforecast').subscribe(
      (result) => {
        this.newsstories = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'hackernewsangulartest.client';
}
