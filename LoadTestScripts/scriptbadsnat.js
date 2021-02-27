import http from 'k6/http';

export const options = {
  ext: {
    loadimpact: {
      projectID: 3508366,
      name: "CloudNativeShow-BadSnat"
    }
  }
};

export default function() {
    let snatendpoint = 'http://20.82.209.44:8080/externalwrong'
    var responce = http.get(snatendpoint);
}