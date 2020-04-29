import { Component, OnInit } from '@angular/core';
import { Apollo } from 'apollo-angular';
import gql from 'graphql-tag';
import { create } from 'domain';


export const CREATE_LIKE_MUTATION = gql`
mutation ($info: InfoInput!, $infoId:ID!)
{
  addLike(info:$info, infoId:$infoId)
      {
        name                            }
  }
`;

export interface CreateLikeMutationResponse {
  updInfo: any;
  loading: boolean;
}

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  infos: any[];
  loading = true;
  error: any;
  updinfo: any;
  id: any;

  constructor(private apollo: Apollo) {}

  createLike(id: string, info: any) {
    this.apollo.mutate<CreateLikeMutationResponse>({
      mutation: CREATE_LIKE_MUTATION,
      variables: {
        info: this.updinfo,
        infoId: this.updinfo.id
      }
    }).subscribe((response) => {

    });
}

updateInfo(isLiked: boolean, info: any) {
  this.updinfo = info;
  this.updinfo.like = isLiked;
  this.createLike(this.updinfo.id, this.updinfo);
}

  ngOnInit() {
    this.apollo
      .query<any>({
        query: gql`
        query {
          infos {
            id,
            name,
            price,
            like
          }
      }
        `
      })
      .subscribe(
        ({ data, loading }) => {
          this.infos = data && data.infos;
          this.loading = loading;
        },
        error => {
          this.loading = false;
          this.error = error;
        }
      );
  }


}
