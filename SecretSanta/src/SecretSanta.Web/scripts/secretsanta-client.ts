﻿﻿/* tslint:disable */
/* eslint-disable */
//----------------------
// <auto-generated>
//     Generated using the NSwag toolchain v13.2.2.0 (NJsonSchema v10.1.4.0 (Newtonsoft.Json v12.0.0.0)) (http://NSwag.org)
// </auto-generated>
//----------------------
// ReSharper disable InconsistentNaming

export interface IGiftClient {
    getAll(): Promise<Gift[]>;
    post(entity: GiftInput): Promise<Gift>;
    get(id: number): Promise<Gift>;
    put(id: number, value: GiftInput): Promise<Gift>;
    delete(id: number): Promise<void>;
}

export class GiftClient implements IGiftClient {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        this.http = http ? http : <any>window;
        this.baseUrl = baseUrl ? baseUrl : "https://localhost:44388";
    }

    getAll(): Promise<Gift[]> {
        let url_ = this.baseUrl + "/api/Gift";
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processGetAll(_response);
        });
    }

    protected processGetAll(response: Response): Promise<Gift[]> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
                let result200: any = null;
                let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                if (Array.isArray(resultData200)) {
                    result200 = [] as any;
                    for (let item of resultData200)
                        result200!.push(Gift.fromJS(item));
                }
                return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<Gift[]>(<any>null);
    }

    post(entity: GiftInput): Promise<Gift> {
        let url_ = this.baseUrl + "/api/Gift";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(entity);

        let options_ = <RequestInit>{
            body: content_,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processPost(_response);
        });
    }

    protected processPost(response: Response): Promise<Gift> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
                let result200: any = null;
                let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result200 = Gift.fromJS(resultData200);
                return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<Gift>(<any>null);
    }

    get(id: number): Promise<Gift> {
        let url_ = this.baseUrl + "/api/Gift/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processGet(_response);
        });
    }

    protected processGet(response: Response): Promise<Gift> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
                let result200: any = null;
                let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result200 = Gift.fromJS(resultData200);
                return result200;
            });
        } else if (status === 404) {
            return response.text().then((_responseText) => {
                let result404: any = null;
                let resultData404 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result404 = ProblemDetails.fromJS(resultData404);
                return throwException("A server side error occurred.", status, _responseText, _headers, result404);
            });
        } else {
            return response.text().then((_responseText) => {
                let resultdefault: any = null;
                let resultDatadefault = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                resultdefault = ProblemDetails.fromJS(resultDatadefault);
                return throwException("A server side error occurred.", status, _responseText, _headers, resultdefault);
            });
        }
    }

    put(id: number, value: GiftInput): Promise<Gift> {
        let url_ = this.baseUrl + "/api/Gift/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(value);

        let options_ = <RequestInit>{
            body: content_,
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processPut(_response);
        });
    }

    protected processPut(response: Response): Promise<Gift> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
                let result200: any = null;
                let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result200 = Gift.fromJS(resultData200);
                return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<Gift>(<any>null);
    }

    delete(id: number): Promise<void> {
        let url_ = this.baseUrl + "/api/Gift/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "DELETE",
            headers: {
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processDelete(_response);
        });
    }

    protected processDelete(response: Response): Promise<void> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
                return;
            });
        } else if (status === 404) {
            return response.text().then((_responseText) => {
                let result404: any = null;
                let resultData404 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result404 = ProblemDetails.fromJS(resultData404);
                return throwException("A server side error occurred.", status, _responseText, _headers, result404);
            });
        } else {
            return response.text().then((_responseText) => {
                let resultdefault: any = null;
                let resultDatadefault = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                resultdefault = ProblemDetails.fromJS(resultDatadefault);
                return throwException("A server side error occurred.", status, _responseText, _headers, resultdefault);
            });
        }
    }
}

export interface IGroupClient {
    getAll(): Promise<Group[]>;
    post(entity: GroupInput): Promise<Group>;
    get(id: number): Promise<Group>;
    put(id: number, value: GroupInput): Promise<Group>;
    delete(id: number): Promise<void>;
}

export class GroupClient implements IGroupClient {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        this.http = http ? http : <any>window;
        this.baseUrl = baseUrl ? baseUrl : "https://localhost:44388";
    }

    getAll(): Promise<Group[]> {
        let url_ = this.baseUrl + "/api/Group";
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processGetAll(_response);
        });
    }

    protected processGetAll(response: Response): Promise<Group[]> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
                let result200: any = null;
                let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                if (Array.isArray(resultData200)) {
                    result200 = [] as any;
                    for (let item of resultData200)
                        result200!.push(Group.fromJS(item));
                }
                return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<Group[]>(<any>null);
    }

    post(entity: GroupInput): Promise<Group> {
        let url_ = this.baseUrl + "/api/Group";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(entity);

        let options_ = <RequestInit>{
            body: content_,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processPost(_response);
        });
    }

    protected processPost(response: Response): Promise<Group> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
                let result200: any = null;
                let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result200 = Group.fromJS(resultData200);
                return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<Group>(<any>null);
    }

    get(id: number): Promise<Group> {
        let url_ = this.baseUrl + "/api/Group/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processGet(_response);
        });
    }

    protected processGet(response: Response): Promise<Group> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
                let result200: any = null;
                let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result200 = Group.fromJS(resultData200);
                return result200;
            });
        } else if (status === 404) {
            return response.text().then((_responseText) => {
                let result404: any = null;
                let resultData404 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result404 = ProblemDetails.fromJS(resultData404);
                return throwException("A server side error occurred.", status, _responseText, _headers, result404);
            });
        } else {
            return response.text().then((_responseText) => {
                let resultdefault: any = null;
                let resultDatadefault = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                resultdefault = ProblemDetails.fromJS(resultDatadefault);
                return throwException("A server side error occurred.", status, _responseText, _headers, resultdefault);
            });
        }
    }

    put(id: number, value: GroupInput): Promise<Group> {
        let url_ = this.baseUrl + "/api/Group/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(value);

        let options_ = <RequestInit>{
            body: content_,
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processPut(_response);
        });
    }

    protected processPut(response: Response): Promise<Group> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
                let result200: any = null;
                let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result200 = Group.fromJS(resultData200);
                return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<Group>(<any>null);
    }

    delete(id: number): Promise<void> {
        let url_ = this.baseUrl + "/api/Group/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "DELETE",
            headers: {
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processDelete(_response);
        });
    }

    protected processDelete(response: Response): Promise<void> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
                return;
            });
        } else if (status === 404) {
            return response.text().then((_responseText) => {
                let result404: any = null;
                let resultData404 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result404 = ProblemDetails.fromJS(resultData404);
                return throwException("A server side error occurred.", status, _responseText, _headers, result404);
            });
        } else {
            return response.text().then((_responseText) => {
                let resultdefault: any = null;
                let resultDatadefault = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                resultdefault = ProblemDetails.fromJS(resultDatadefault);
                return throwException("A server side error occurred.", status, _responseText, _headers, resultdefault);
            });
        }
    }
}

export interface IUserClient {
    getAll(): Promise<User[]>;
    post(entity: UserInput): Promise<User>;
    get(id: number): Promise<User>;
    put(id: number, value: UserInput): Promise<User>;
    delete(id: number): Promise<void>;
}

export class UserClient implements IUserClient {
    private http: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> };
    private baseUrl: string;
    protected jsonParseReviver: ((key: string, value: any) => any) | undefined = undefined;

    constructor(baseUrl?: string, http?: { fetch(url: RequestInfo, init?: RequestInit): Promise<Response> }) {
        this.http = http ? http : <any>window;
        this.baseUrl = baseUrl ? baseUrl : "https://localhost:44388";
    }

    getAll(): Promise<User[]> {
        let url_ = this.baseUrl + "/api/User";
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processGetAll(_response);
        });
    }

    protected processGetAll(response: Response): Promise<User[]> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
                let result200: any = null;
                let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                if (Array.isArray(resultData200)) {
                    result200 = [] as any;
                    for (let item of resultData200)
                        result200!.push(User.fromJS(item));
                }
                return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<User[]>(<any>null);
    }

    post(entity: UserInput): Promise<User> {
        let url_ = this.baseUrl + "/api/User";
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(entity);

        let options_ = <RequestInit>{
            body: content_,
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processPost(_response);
        });
    }

    protected processPost(response: Response): Promise<User> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
                let result200: any = null;
                let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result200 = User.fromJS(resultData200);
                return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<User>(<any>null);
    }

    get(id: number): Promise<User> {
        let url_ = this.baseUrl + "/api/User/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "GET",
            headers: {
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processGet(_response);
        });
    }

    protected processGet(response: Response): Promise<User> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
                let result200: any = null;
                let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result200 = User.fromJS(resultData200);
                return result200;
            });
        } else if (status === 404) {
            return response.text().then((_responseText) => {
                let result404: any = null;
                let resultData404 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result404 = ProblemDetails.fromJS(resultData404);
                return throwException("A server side error occurred.", status, _responseText, _headers, result404);
            });
        } else {
            return response.text().then((_responseText) => {
                let resultdefault: any = null;
                let resultDatadefault = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                resultdefault = ProblemDetails.fromJS(resultDatadefault);
                return throwException("A server side error occurred.", status, _responseText, _headers, resultdefault);
            });
        }
    }

    put(id: number, value: UserInput): Promise<User> {
        let url_ = this.baseUrl + "/api/User/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        url_ = url_.replace(/[?&]$/, "");

        const content_ = JSON.stringify(value);

        let options_ = <RequestInit>{
            body: content_,
            method: "PUT",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processPut(_response);
        });
    }

    protected processPut(response: Response): Promise<User> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
                let result200: any = null;
                let resultData200 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result200 = User.fromJS(resultData200);
                return result200;
            });
        } else if (status !== 200 && status !== 204) {
            return response.text().then((_responseText) => {
                return throwException("An unexpected server error occurred.", status, _responseText, _headers);
            });
        }
        return Promise.resolve<User>(<any>null);
    }

    delete(id: number): Promise<void> {
        let url_ = this.baseUrl + "/api/User/{id}";
        if (id === undefined || id === null)
            throw new Error("The parameter 'id' must be defined.");
        url_ = url_.replace("{id}", encodeURIComponent("" + id));
        url_ = url_.replace(/[?&]$/, "");

        let options_ = <RequestInit>{
            method: "DELETE",
            headers: {
            }
        };

        return this.http.fetch(url_, options_).then((_response: Response) => {
            return this.processDelete(_response);
        });
    }

    protected processDelete(response: Response): Promise<void> {
        const status = response.status;
        let _headers: any = {}; if (response.headers && response.headers.forEach) { response.headers.forEach((v: any, k: any) => _headers[k] = v); };
        if (status === 200) {
            return response.text().then((_responseText) => {
                return;
            });
        } else if (status === 404) {
            return response.text().then((_responseText) => {
                let result404: any = null;
                let resultData404 = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                result404 = ProblemDetails.fromJS(resultData404);
                return throwException("A server side error occurred.", status, _responseText, _headers, result404);
            });
        } else {
            return response.text().then((_responseText) => {
                let resultdefault: any = null;
                let resultDatadefault = _responseText === "" ? null : JSON.parse(_responseText, this.jsonParseReviver);
                resultdefault = ProblemDetails.fromJS(resultDatadefault);
                return throwException("A server side error occurred.", status, _responseText, _headers, resultdefault);
            });
        }
    }
}

export class GiftInput implements IGiftInput {
    title!: string;
    description!: string;
    url!: string;
    userId!: number;

    constructor(data?: IGiftInput) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.title = _data["title"];
            this.description = _data["description"];
            this.url = _data["url"];
            this.userId = _data["userId"];
        }
    }

    static fromJS(data: any): GiftInput {
        data = typeof data === 'object' ? data : {};
        let result = new GiftInput();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["title"] = this.title;
        data["description"] = this.description;
        data["url"] = this.url;
        data["userId"] = this.userId;
        return data;
    }
}

export interface IGiftInput {
    title: string;
    description: string;
    url: string;
    userId: number;
}

export class Gift extends GiftInput implements IGift {
    id!: number;

    constructor(data?: IGift) {
        super(data);
    }

    init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.id = _data["id"];
        }
    }

    static fromJS(data: any): Gift {
        data = typeof data === 'object' ? data : {};
        let result = new Gift();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        super.toJSON(data);
        return data;
    }
}

export interface IGift extends IGiftInput {
    id: number;
}

export class ProblemDetails implements IProblemDetails {
    type?: string | undefined;
    title?: string | undefined;
    status?: number | undefined;
    detail?: string | undefined;
    instance?: string | undefined;
    extensions?: { [key: string]: any; } | undefined;

    constructor(data?: IProblemDetails) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.type = _data["type"];
            this.title = _data["title"];
            this.status = _data["status"];
            this.detail = _data["detail"];
            this.instance = _data["instance"];
            if (_data["extensions"]) {
                this.extensions = {} as any;
                for (let key in _data["extensions"]) {
                    if (_data["extensions"].hasOwnProperty(key))
                        this.extensions![key] = _data["extensions"][key];
                }
            }
        }
    }

    static fromJS(data: any): ProblemDetails {
        data = typeof data === 'object' ? data : {};
        let result = new ProblemDetails();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["type"] = this.type;
        data["title"] = this.title;
        data["status"] = this.status;
        data["detail"] = this.detail;
        data["instance"] = this.instance;
        if (this.extensions) {
            data["extensions"] = {};
            for (let key in this.extensions) {
                if (this.extensions.hasOwnProperty(key))
                    data["extensions"][key] = this.extensions[key];
            }
        }
        return data;
    }
}

export interface IProblemDetails {
    type?: string | undefined;
    title?: string | undefined;
    status?: number | undefined;
    detail?: string | undefined;
    instance?: string | undefined;
    extensions?: { [key: string]: any; } | undefined;
}

export class GroupInput implements IGroupInput {
    title!: string;

    constructor(data?: IGroupInput) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.title = _data["title"];
        }
    }

    static fromJS(data: any): GroupInput {
        data = typeof data === 'object' ? data : {};
        let result = new GroupInput();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["title"] = this.title;
        return data;
    }
}

export interface IGroupInput {
    title: string;
}

export class Group extends GroupInput implements IGroup {
    id!: number;
    users!: User[];

    constructor(data?: IGroup) {
        super(data);
        if (!data) {
            this.users = [];
        }
    }

    init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.id = _data["id"];
            if (Array.isArray(_data["users"])) {
                this.users = [] as any;
                for (let item of _data["users"])
                    this.users!.push(User.fromJS(item));
            }
        }
    }

    static fromJS(data: any): Group {
        data = typeof data === 'object' ? data : {};
        let result = new Group();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        if (Array.isArray(this.users)) {
            data["users"] = [];
            for (let item of this.users)
                data["users"].push(item.toJSON());
        }
        super.toJSON(data);
        return data;
    }
}

export interface IGroup extends IGroupInput {
    id: number;
    users: User[];
}

export class UserInput implements IUserInput {
    firstName!: string;
    lastName!: string;
    santaId?: number | undefined;

    constructor(data?: IUserInput) {
        if (data) {
            for (var property in data) {
                if (data.hasOwnProperty(property))
                    (<any>this)[property] = (<any>data)[property];
            }
        }
    }

    init(_data?: any) {
        if (_data) {
            this.firstName = _data["firstName"];
            this.lastName = _data["lastName"];
            this.santaId = _data["santaId"];
        }
    }

    static fromJS(data: any): UserInput {
        data = typeof data === 'object' ? data : {};
        let result = new UserInput();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["firstName"] = this.firstName;
        data["lastName"] = this.lastName;
        data["santaId"] = this.santaId;
        return data;
    }
}

export interface IUserInput {
    firstName: string;
    lastName: string;
    santaId?: number | undefined;
}

export class User extends UserInput implements IUser {
    id!: number;
    gifts!: Gift[];
    groups!: Group[];

    constructor(data?: IUser) {
        super(data);
        if (!data) {
            this.gifts = [];
            this.groups = [];
        }
    }

    init(_data?: any) {
        super.init(_data);
        if (_data) {
            this.id = _data["id"];
            if (Array.isArray(_data["gifts"])) {
                this.gifts = [] as any;
                for (let item of _data["gifts"])
                    this.gifts!.push(Gift.fromJS(item));
            }
            if (Array.isArray(_data["groups"])) {
                this.groups = [] as any;
                for (let item of _data["groups"])
                    this.groups!.push(Group.fromJS(item));
            }
        }
    }

    static fromJS(data: any): User {
        data = typeof data === 'object' ? data : {};
        let result = new User();
        result.init(data);
        return result;
    }

    toJSON(data?: any) {
        data = typeof data === 'object' ? data : {};
        data["id"] = this.id;
        if (Array.isArray(this.gifts)) {
            data["gifts"] = [];
            for (let item of this.gifts)
                data["gifts"].push(item.toJSON());
        }
        if (Array.isArray(this.groups)) {
            data["groups"] = [];
            for (let item of this.groups)
                data["groups"].push(item.toJSON());
        }
        super.toJSON(data);
        return data;
    }
}

export interface IUser extends IUserInput {
    id: number;
    gifts: Gift[];
    groups: Group[];
}

export class ApiException extends Error {
    message: string;
    status: number;
    response: string;
    headers: { [key: string]: any; };
    result: any;

    constructor(message: string, status: number, response: string, headers: { [key: string]: any; }, result: any) {
        super();

        this.message = message;
        this.status = status;
        this.response = response;
        this.headers = headers;
        this.result = result;
    }

    protected isApiException = true;

    static isApiException(obj: any): obj is ApiException {
        return obj.isApiException === true;
    }
}

function throwException(message: string, status: number, response: string, headers: { [key: string]: any; }, result?: any): any {
    if (result !== null && result !== undefined)
        throw result;
    else
        throw new ApiException(message, status, response, headers, null);
}