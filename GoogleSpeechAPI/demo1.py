import io
from google.oauth2 import service_account
from google.cloud import speech

client_file = 'studied-point-387806-5ffc51a0470f.json'
credentials = service_account.Credentials.from_service_account_file(client_file)
client = speech.SpeechClient(credentials=credentials)

#Audio File
audio_file = 'audio sample.wav'
with io.open(audio_file, 'rb') as f:
    content = f.read()
    audio = speech.RecognitionAudio(content=content)

config = speech.RecognitionConfig(
    encoding=speech.RecognitionConfig.AudioEncoding.LINEAR16,
    sample_rate_hertz=48000,
    language_code='en-GB'
)

response = client.recognize(config=config,audio=audio)
print(response)