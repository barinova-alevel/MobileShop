import { inject, injectable } from 'inversify'
import { types } from '../ioc'
import { AuthStore } from '../stores/AuthStore'

export interface IHttpService {
  postAsync: <T>(path: string, payload?: any) => Promise<T>
}

@injectable()
export default class HttpService implements IHttpService {
  @inject(types.authStore)
  private readonly _authStore!: AuthStore
  private readonly _baseUrl = process.env.REACT_APP_BASE_API_URL!

  private readonly handleResponse = async (response: Response) => {
    if (!response.ok) {
      const message = await response.json()
      throw Error(message.error || 'Request error')
    }

    return response.json();
  }

  public readonly postAsync = async <T>(path: string, payload?: any) => {
    const accessToken = this._authStore?.user?.access_token;
    const headers: { [key: string]: string } = {
      'Content-Type': 'application/json',
    }

    if (accessToken) {
      headers.Authorization = `Bearer ${accessToken}`;
    }

    return await fetch(`${this._baseUrl}${path}`, {
      method: 'POST',
      mode: "cors",
      headers: headers,
      body: payload ? JSON.stringify(payload) : undefined
    })
    .then(this.handleResponse)
  }
}



