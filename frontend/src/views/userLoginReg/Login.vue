<template>
  <div class="main">
    <a-form
      id="formLogin"
      class="user-layout-login"
      ref="formLogin"
      :form="form"
      @submit="handleSubmit"
    >
      <a-tabs
        :activeKey="customActiveKey"
        :tabBarStyle="{ textAlign: 'center', borderBottom: 'unset' }"
        @change="handleTabClick"
      >
        <a-tab-pane key="tab1" tab="账号密码登录">
          <a-alert v-if="isLoginError" type="error" showIcon style="margin-bottom: 24px;" :message="this.accountLoginErrMsg" />

          <a-form-item>
            <a-input
              size="large"
              type="text"
              placeholder="账号"
              v-decorator="[
                'account',{ initialValue:'', rules: [{ required: true, message: '请输入账号' }, { validator: handleUsernameOrEmail }], validateTrigger: 'change'}
              ]"
            >
              <a-icon slot="prefix" type="user" :style="{ color: 'rgba(0,0,0,.25)' }"/>
            </a-input>
          </a-form-item>

          <a-form-item>
            <a-input
              size="large"
              type="password"
              autocomplete="false"
              placeholder="密码"
              v-decorator="[
                'password',
                { initialValue:'', rules: [{ required: true, message: '请输入密码' }], validateTrigger: 'blur'}
              ]"
            >
              <a-icon slot="prefix" type="lock" :style="{ color: 'rgba(0,0,0,.25)' }"/>
            </a-input>
          </a-form-item>
        </a-tab-pane>

      </a-tabs>

      <a-form-item style="margin-top:24px">
        <a-button
          size="large"
          type="primary"
          htmlType="submit"
          class="login-button"
          :loading="state.loginBtn"
          :disabled="state.loginBtn"
        >确定</a-button>
      </a-form-item>
    </a-form>
  </div>
</template>

<script>
import Vue from 'vue'
import TwoStepCaptcha from '@/components/tools/TwoStepCaptcha'
import { mapActions } from 'vuex'
import Verify from '@/components/verifition/Verify'

export default {
  components: {
    TwoStepCaptcha,
    Verify
  },
  data () {
    return {
      customActiveKey: 'tab1',
      loginBtn: false,
      // login type: 0 email, 1 username, 2 telephone
      loginType: 0,
      isLoginError: false,
      form: this.$form.createForm(this),
      state: {
        time: 60,
        loginBtn: false,
        // login type: 0 email, 1 username, 2 telephone
        loginType: 0,
        smsSendBtn: false
      },
      accountLoginErrMsg: '',
      tenantOpen: false,
      tenantsList: [],
      loginParams: [] // 登录参数

    }
  },
  created () {
  },
  mounted () {
    this.getLocalStorageData()
  },
  methods: {
    ...mapActions(['Login', 'Logout', 'dictTypeData']),
    // handler
    handleUsernameOrEmail (rule, value, callback) {
      const { state } = this
      const regex = /^([a-zA-Z0-9_-])+@([a-zA-Z0-9_-])+((\.[a-zA-Z0-9_-]{2,3}){1,2})$/
      if (regex.test(value)) {
        state.loginType = 0
      } else {
        state.loginType = 1
      }
      callback()
    },
    handleTabClick (key) {
      this.isLoginError = false
      this.customActiveKey = key
      // this.form.resetFields()
    },
    handleSubmit (e) {
      e.preventDefault()
      const {
        form: { validateFields },
        state,
        customActiveKey,
        Login
      } = this

      state.loginBtn = true
      const validateFieldsKey = customActiveKey === 'tab1' ? ['account', 'password'] : ['mobile', 'captcha']
      if (this.tenantOpen) {
        validateFieldsKey.push('tenantCode')
      }
      validateFields(validateFieldsKey, { force: true }, (err, values) => {
        this.loginParams = values
        if (!err) {
          const loginParams = { ...values }
          delete loginParams.account
          loginParams[!state.loginType ? 'account' : 'account'] = values.account
          loginParams.password = values.password
          if (this.tenantOpen) {
            loginParams.tenantCode = values.tenantCode
          }
          Login(loginParams)
            .then((res) => this.loginSuccess(res))
            .catch(err => this.requestFailed(err))
            .finally(() => {
              state.loginBtn = false
            })
        } else {
          setTimeout(() => {
            state.loginBtn = false
          }, 600)
        }
      })
    },
    loginSuccess (res) {
      this.setLocalStorageData()
      this.$router.push({ path: '/' })
      this.isLoginError = false
      // 加载字典所有字典到缓存中
      this.dictTypeData().then((res) => { })
    },
    requestFailed (err) {
      this.accountLoginErrMsg = err
      this.isLoginError = true
    },
    /**
     * 从 localStorage 中读取信息
     */
    getLocalStorageData () {
      const account = Vue.ls.get('LOGIN_ACCOUNT')
      if (account) {
        this.form.setFieldsValue(
          {
            account: account,
            rememberMe: true
          }
        )
      }
    },
    /**
     * 将信息写入 localStorage
     */
    setLocalStorageData () {
      if (this.form.getFieldValue('rememberMe')) {
        Vue.ls.set('LOGIN_ACCOUNT', this.form.getFieldValue('account'))
      } else {
        Vue.ls.remove('LOGIN_ACCOUNT')
      }
    }
  }
}
</script>

<style lang="less" scoped>
.user-layout-login {
  label {
    font-size: 14px;
  }

  .forge-password {
    font-size: 14px;
  }

  button.login-button {
    padding: 0 15px;
    font-size: 16px;
    height: 40px;
    width: 100%;
  }

  .user-login-other {
    text-align: left;
    margin-top: 24px;
    line-height: 22px;

    .item-icon {
      font-size: 24px;
      color: rgba(0, 0, 0, 0.2);
      margin-left: 16px;
      vertical-align: middle;
      cursor: pointer;
      transition: color 0.3s;

      &:hover {
        color: #1890ff;
      }
    }

    .register {
      float: right;
    }
  }
}
</style>
